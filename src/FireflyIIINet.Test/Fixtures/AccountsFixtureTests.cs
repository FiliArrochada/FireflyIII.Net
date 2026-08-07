/*
 * Fixture tests: deserialization of realistic Account payloads built from the
 * example values in api/firefly-iii-2.0.2-v1.yaml (Account / AccountRead schemas).
 *
 * Note: properties generated as read-only (private setters, e.g. created_at,
 * currency_symbol, current_balance) are included in the payloads for realism but
 * are not asserted: System.Text.Json does not populate non-public setters
 * without [JsonInclude].
 */

using System;
using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class AccountsFixtureTests
    {
        private const string AccountSingleJson = """
        {
          "data": {
            "type": "accounts",
            "id": "2",
            "attributes": {
              "created_at": "2018-09-17T12:46:47+01:00",
              "updated_at": "2018-09-17T12:46:47+01:00",
              "active": true,
              "order": 1,
              "name": "My checking account",
              "type": "asset",
              "account_role": "defaultAsset",
              "currency_id": "12",
              "currency_code": "EUR",
              "currency_symbol": "$",
              "currency_decimal_places": 2,
              "current_balance": "123.45",
              "current_balance_date": "2018-09-17T12:46:47+01:00",
              "iban": "GB98MIDL07009312345678",
              "bic": "BOFAUS3N",
              "account_number": "7009312345678",
              "opening_balance": "-1012.12",
              "current_debt": null,
              "opening_balance_date": "2018-09-17T12:46:47+01:00",
              "virtual_balance": "123.45",
              "include_net_worth": true,
              "credit_card_type": null,
              "monthly_payment_date": null,
              "liability_type": null,
              "liability_direction": null,
              "interest": null,
              "interest_period": null,
              "notes": null,
              "latitude": 51.983333,
              "longitude": 5.916667,
              "zoom_level": 6
            }
          }
        }
        """;

        private const string AccountArrayJson = """
        {
          "data": [
            {
              "type": "accounts",
              "id": "2",
              "attributes": {
                "created_at": "2018-09-17T12:46:47+01:00",
                "updated_at": "2018-09-17T12:46:47+01:00",
                "active": true,
                "order": 1,
                "name": "My checking account",
                "type": "asset",
                "account_role": "defaultAsset",
                "currency_code": "EUR",
                "opening_balance": "-1012.12",
                "virtual_balance": "123.45",
                "include_net_worth": true
              }
            },
            {
              "type": "accounts",
              "id": "18",
              "attributes": {
                "created_at": "2018-09-17T12:46:47+01:00",
                "updated_at": "2018-09-17T12:46:47+01:00",
                "active": true,
                "order": null,
                "name": "Groceries store",
                "type": "expense",
                "currency_code": "EUR",
                "opening_balance": "0",
                "virtual_balance": "0",
                "include_net_worth": true
              }
            }
          ],
          "meta": {
            "pagination": {
              "total": 2,
              "count": 2,
              "per_page": 50,
              "current_page": 1,
              "total_pages": 1
            }
          }
        }
        """;

        [Fact]
        public void AccountSingle_Deserializes_Spec_Example()
        {
            var single = JsonSerializer.Deserialize<AccountSingle>(AccountSingleJson, SerializerOptions.Default);

            Assert.NotNull(single);
            Assert.Equal("accounts", single.Data.Type);
            Assert.Equal("2", single.Data.Id);

            var account = single.Data.Attributes;
            Assert.Equal("My checking account", account.Name);
            Assert.Equal(ShortAccountTypeProperty.Asset, account.Type);
            Assert.Equal(AccountRoleProperty.DefaultAsset, account.AccountRole);
            Assert.True(account.Active);
            Assert.Equal(1, account.Order);
            Assert.Equal("EUR", account.CurrencyCode);
            Assert.Equal("GB98MIDL07009312345678", account.Iban);
            Assert.Equal("BOFAUS3N", account.Bic);
            Assert.Equal("-1012.12", account.OpeningBalance);

            // RFC3339 date-time with offset: compare the instant, not the local kind.
            Assert.NotNull(account.OpeningBalanceDate);
            Assert.Equal(
                new DateTime(2018, 9, 17, 11, 46, 47, DateTimeKind.Utc),
                account.OpeningBalanceDate.Value.ToUniversalTime());

            Assert.Equal(51.983333, account.Latitude);
            Assert.Equal(6, account.ZoomLevel);
        }

        [Fact]
        public void AccountSingle_Explicit_Nulls_Deserialize_Without_Error()
        {
            var single = JsonSerializer.Deserialize<AccountSingle>(AccountSingleJson, SerializerOptions.Default);

            var account = single.Data.Attributes;
            Assert.Null(account.CreditCardType);
            Assert.Null(account.LiabilityType);
            Assert.Null(account.LiabilityDirection);
            Assert.Null(account.InterestPeriod);
            Assert.Null(account.MonthlyPaymentDate);
            Assert.Null(account.CurrentDebt);
            Assert.Null(account.Notes);
        }

        [Fact]
        public void AccountArray_Deserializes_Spec_Example()
        {
            var array = JsonSerializer.Deserialize<AccountArray>(AccountArrayJson, SerializerOptions.Default);

            Assert.NotNull(array);
            Assert.Equal(2, array.Data.Count);

            Assert.Equal("2", array.Data[0].Id);
            Assert.Equal(ShortAccountTypeProperty.Asset, array.Data[0].Attributes.Type);

            Assert.Equal("18", array.Data[1].Id);
            Assert.Equal("Groceries store", array.Data[1].Attributes.Name);
            Assert.Equal(ShortAccountTypeProperty.Expense, array.Data[1].Attributes.Type);
            Assert.Null(array.Data[1].Attributes.Order);

            Assert.Equal(2, array.Meta.Pagination.Total);
            Assert.Equal(2, array.Meta.Pagination.Count);
            Assert.Equal(50, array.Meta.Pagination.PerPage);
            Assert.Equal(1, array.Meta.Pagination.CurrentPage);
            Assert.Equal(1, array.Meta.Pagination.TotalPages);
        }
    }
}
