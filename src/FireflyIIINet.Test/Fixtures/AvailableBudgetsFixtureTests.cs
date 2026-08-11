/*
 * Fixture tests built from the Firefly III OpenAPI spec examples (firefly-iii-2.0.10-v1.yaml),
 * asserting the wire format maps onto the generated models.
 *
 * Note: properties the spec marks readOnly (created_at, currency_symbol, currency_decimal_places,
 * spent_in_budgets, spent_outside_budget) are generated with private setters and are therefore
 * NOT populated by System.Text.Json deserialization. They are kept in the payload to prove they
 * parse without error, but their values are not asserted. The available-budget area has no
 * enum-typed model property, so no enum assertion is possible here.
 */

using System;
using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class AvailableBudgetsFixtureTests
    {
        private const string AvailableBudgetSingleJson = """
        {
          "data": {
            "type": "available_budgets",
            "id": "2",
            "attributes": {
              "created_at": "2018-09-17T12:46:47+01:00",
              "updated_at": "2018-09-17T12:46:47+01:00",
              "currency_id": "5",
              "currency_code": "EUR",
              "currency_symbol": "$",
              "currency_decimal_places": 2,
              "amount": "123.45",
              "start": "2018-09-01T00:00:00+01:00",
              "end": "2018-09-30T23:59:59+01:00",
              "spent_in_budgets": [
                {
                  "sum": "123.45",
                  "currency_id": "5",
                  "currency_code": "USD",
                  "currency_symbol": "$",
                  "currency_decimal_places": 2
                }
              ],
              "spent_outside_budget": []
            }
          }
        }
        """;

        private const string AvailableBudgetSingleMinimalJson = """
        {
          "data": {
            "type": "available_budgets",
            "id": "7",
            "attributes": {
              "amount": "250.00",
              "start": "2018-09-01T00:00:00Z",
              "end": "2018-09-30T23:59:59Z"
            }
          }
        }
        """;

        [Fact]
        public void AvailableBudgetSingle_Deserializes_Spec_Example()
        {
            var single = JsonSerializer.Deserialize<AvailableBudgetSingle>(AvailableBudgetSingleJson, SerializerOptions.Default);

            Assert.NotNull(single);
            Assert.Equal("available_budgets", single.Data.Type);
            Assert.Equal("2", single.Data.Id);

            var budget = single.Data.Attributes;
            Assert.Equal("123.45", budget.Amount);
            Assert.Equal("5", budget.CurrencyId);
            Assert.Equal("EUR", budget.CurrencyCode);
            // RFC3339 values with an offset are adjusted; compare in UTC to stay timezone-agnostic.
            Assert.Equal(new DateTime(2018, 8, 31, 23, 0, 0, DateTimeKind.Utc), budget.Start.ToUniversalTime());
            Assert.Equal(new DateTime(2018, 9, 30, 22, 59, 59, DateTimeKind.Utc), budget.End.ToUniversalTime());
        }

        [Fact]
        public void AvailableBudgetSingle_Minimal_Payload_Deserializes()
        {
            var single = JsonSerializer.Deserialize<AvailableBudgetSingle>(AvailableBudgetSingleMinimalJson, SerializerOptions.Default);

            Assert.Equal("7", single.Data.Id);

            var budget = single.Data.Attributes;
            Assert.Equal("250.00", budget.Amount);
            Assert.Null(budget.CurrencyId);
            Assert.Null(budget.CurrencyCode);
            Assert.Equal(new DateTime(2018, 9, 1, 0, 0, 0, DateTimeKind.Utc), budget.Start.ToUniversalTime());
            Assert.Equal(new DateTime(2018, 9, 30, 23, 59, 59, DateTimeKind.Utc), budget.End.ToUniversalTime());
        }
    }
}
