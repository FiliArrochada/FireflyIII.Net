/*
 * Fixture tests built from the Firefly III OpenAPI spec examples (v1: firefly-iii-6.1.21-v1.yaml,
 * v2: firefly-iii-6.1.21-v2.yaml), asserting the wire format maps onto the generated models.
 *
 * Note: properties the spec marks readOnly (created_at, order, budget_id, period, spent, ...)
 * are generated with private setters and are therefore NOT populated by System.Text.Json
 * deserialization. They are kept in the payloads to prove they parse without error, but their
 * values are not asserted.
 */

using System;
using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class BudgetsFixtureTests
    {
        private const string BudgetSingleJson = """
        {
          "data": {
            "type": "budgets",
            "id": "2",
            "attributes": {
              "created_at": "2018-09-17T12:46:47+01:00",
              "updated_at": "2018-09-17T12:46:47+01:00",
              "name": "Bills",
              "active": false,
              "notes": "Some notes",
              "order": 5,
              "auto_budget_type": "reset",
              "auto_budget_currency_id": "12",
              "auto_budget_currency_code": "EUR",
              "auto_budget_amount": "-1012.12",
              "auto_budget_period": "monthly",
              "spent": [
                {
                  "sum": "123.45",
                  "currency_id": "5",
                  "currency_code": "USD",
                  "currency_symbol": "$",
                  "currency_decimal_places": 2
                }
              ]
            }
          }
        }
        """;

        private const string BudgetSingleNullAutoBudgetJson = """
        {
          "data": {
            "type": "budgets",
            "id": "3",
            "attributes": {
              "created_at": "2018-09-17T12:46:47+01:00",
              "updated_at": "2018-09-17T12:46:47+01:00",
              "name": "Groceries",
              "active": true,
              "notes": null,
              "order": 1,
              "auto_budget_type": null,
              "auto_budget_currency_id": null,
              "auto_budget_currency_code": null,
              "auto_budget_amount": null,
              "auto_budget_period": null
            }
          }
        }
        """;

        private const string BudgetLimitSingleJson = """
        {
          "data": {
            "type": "budget_limits",
            "id": "2",
            "attributes": {
              "created_at": "2018-09-17T12:46:47+01:00",
              "updated_at": "2018-09-17T12:46:47+01:00",
              "start": "2018-09-01T00:00:00+01:00",
              "end": "2018-09-30T23:59:59+01:00",
              "currency_id": "5",
              "currency_code": "EUR",
              "currency_name": "Euro",
              "currency_symbol": "$",
              "currency_decimal_places": 2,
              "budget_id": "23",
              "period": "monthly",
              "amount": "123.45",
              "spent": "-1012.12"
            }
          }
        }
        """;

        [Fact]
        public void BudgetSingle_Deserializes_Spec_Example()
        {
            var single = JsonSerializer.Deserialize<BudgetSingle>(BudgetSingleJson, SerializerOptions.Default);

            Assert.NotNull(single);
            Assert.Equal("budgets", single.Data.Type);
            Assert.Equal("2", single.Data.Id);

            var budget = single.Data.Attributes;
            Assert.Equal("Bills", budget.Name);
            Assert.False(budget.Active);
            Assert.Equal("Some notes", budget.Notes);
            Assert.Equal(AutoBudgetType.Reset, budget.AutoBudgetType);
            Assert.Equal(AutoBudgetPeriod.Monthly, budget.AutoBudgetPeriod);
            Assert.Equal("12", budget.AutoBudgetCurrencyId);
            Assert.Equal("EUR", budget.AutoBudgetCurrencyCode);
            Assert.Equal("-1012.12", budget.AutoBudgetAmount);
        }

        [Fact]
        public void BudgetSingle_With_Explicit_Null_AutoBudget_Fields_Deserializes()
        {
            var single = JsonSerializer.Deserialize<BudgetSingle>(BudgetSingleNullAutoBudgetJson, SerializerOptions.Default);

            var budget = single.Data.Attributes;
            Assert.Equal("Groceries", budget.Name);
            Assert.True(budget.Active);
            Assert.Null(budget.Notes);
            Assert.Null(budget.AutoBudgetType);
            Assert.Null(budget.AutoBudgetPeriod);
            Assert.Null(budget.AutoBudgetCurrencyId);
            Assert.Null(budget.AutoBudgetCurrencyCode);
            Assert.Null(budget.AutoBudgetAmount);
        }

        [Fact]
        public void BudgetLimitSingle_Deserializes_Spec_Example()
        {
            var single = JsonSerializer.Deserialize<BudgetLimitSingle>(BudgetLimitSingleJson, SerializerOptions.Default);

            Assert.Equal("budget_limits", single.Data.Type);
            Assert.Equal("2", single.Data.Id);

            var limit = single.Data.Attributes;
            Assert.Equal("123.45", limit.Amount);
            Assert.Equal("5", limit.CurrencyId);
            Assert.Equal("EUR", limit.CurrencyCode);
            // RFC3339 values with an offset are adjusted; compare in UTC to stay timezone-agnostic.
            Assert.Equal(new DateTime(2018, 8, 31, 23, 0, 0, DateTimeKind.Utc), limit.Start.ToUniversalTime());
            Assert.Equal(new DateTime(2018, 9, 30, 22, 59, 59, DateTimeKind.Utc), limit.End.ToUniversalTime());
        }
    }
}
