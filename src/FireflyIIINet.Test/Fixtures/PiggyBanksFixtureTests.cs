/*
 * Fixture tests built from the Firefly III OpenAPI spec examples (firefly-iii-2.0.14-v1.yaml),
 * asserting the wire format maps onto the generated models.
 *
 * Note: properties the spec marks readOnly (percentage, left_to_save, save_per_month,
 * currency_*, account_name, active, created_at, ...) are generated with private setters and are
 * therefore NOT populated by System.Text.Json deserialization. They are kept in the payloads to
 * prove they parse without error, but their values are not asserted. The piggy bank area has no
 * enum-typed model property, so no enum assertion is possible here.
 */

using System;
using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class PiggyBanksFixtureTests
    {
        private const string PiggyBankSingleJson = """
        {
          "data": {
            "type": "piggy_banks",
            "id": "2",
            "attributes": {
              "created_at": "2018-09-17T12:46:47+01:00",
              "updated_at": "2018-09-17T12:46:47+01:00",
              "account_id": "13",
              "account_name": "Savings account",
              "name": "New digital camera",
              "currency_id": "5",
              "currency_code": "USD",
              "currency_symbol": "$",
              "currency_decimal_places": 2,
              "target_amount": "123.45",
              "percentage": 12.5,
              "current_amount": "123.45",
              "left_to_save": "700.00",
              "save_per_month": "12.45",
              "start_date": "2018-09-17",
              "target_date": "2019-09-17",
              "order": 5,
              "active": true,
              "notes": "Some notes",
              "object_group_id": "5",
              "object_group_order": 5,
              "object_group_title": "Example Group"
            },
            "links": {
              "0": {
                "rel": "self",
                "uri": "/piggy_banks/2"
              },
              "self": "https://demo.firefly-iii.org/api/v1/piggy_banks/2"
            }
          }
        }
        """;

        private const string PiggyBankSingleNullsJson = """
        {
          "data": {
            "type": "piggy_banks",
            "id": "9",
            "attributes": {
              "account_id": "13",
              "name": "Rainy day fund",
              "target_amount": null,
              "percentage": null,
              "current_amount": "50.00",
              "left_to_save": null,
              "save_per_month": null,
              "start_date": "2018-09-17",
              "target_date": null,
              "order": 1,
              "notes": null,
              "object_group_id": null,
              "object_group_title": null
            }
          }
        }
        """;

        private const string PiggyBankEventArrayJson = """
        {
          "data": [
            {
              "type": "piggy_bank_events",
              "id": "2",
              "attributes": {
                "created_at": "2018-09-17T12:46:47+01:00",
                "updated_at": "2018-09-17T12:46:47+01:00",
                "currency_id": "5",
                "currency_code": "EUR",
                "currency_symbol": "$",
                "currency_decimal_places": 2,
                "amount": "123.45",
                "transaction_journal_id": "4291",
                "transaction_group_id": "4291"
              },
              "links": {
                "0": {
                  "rel": "self",
                  "uri": "/piggy_bank_events/2"
                },
                "self": "https://demo.firefly-iii.org/api/v1/piggy_bank_events/2"
              }
            },
            {
              "type": "piggy_bank_events",
              "id": "3",
              "attributes": {
                "created_at": "2018-10-17T12:46:47+01:00",
                "updated_at": "2018-10-17T12:46:47+01:00",
                "currency_id": "5",
                "currency_code": "EUR",
                "currency_symbol": "$",
                "currency_decimal_places": 2,
                "amount": "-123.45",
                "transaction_journal_id": "4292",
                "transaction_group_id": "4292"
              },
              "links": {
                "0": {
                  "rel": "self",
                  "uri": "/piggy_bank_events/3"
                },
                "self": "https://demo.firefly-iii.org/api/v1/piggy_bank_events/3"
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
          },
          "links": {
            "self": "https://demo.firefly-iii.org/api/v1/piggy-banks/1/events?page=1",
            "first": "https://demo.firefly-iii.org/api/v1/piggy-banks/1/events?page=1",
            "last": "https://demo.firefly-iii.org/api/v1/piggy-banks/1/events?page=1"
          }
        }
        """;

        [Fact]
        public void PiggyBankSingle_Deserializes_Spec_Example()
        {
            var single = JsonSerializer.Deserialize<PiggyBankSingle>(PiggyBankSingleJson, SerializerOptions.Default);

            Assert.NotNull(single);
            Assert.Equal("piggy_banks", single.Data.Type);
            Assert.Equal("2", single.Data.Id);

            var piggy = single.Data.Attributes;
            Assert.Equal("13", piggy.AccountId);
            Assert.Equal("New digital camera", piggy.Name);
            Assert.Equal("123.45", piggy.TargetAmount);
            Assert.Equal("123.45", piggy.CurrentAmount);
            // start_date/target_date are date-only (yyyy-MM-dd) on the wire.
            Assert.Equal(new DateTime(2018, 9, 17), piggy.StartDate);
            Assert.Equal(new DateTime(2019, 9, 17), piggy.TargetDate);
            Assert.Equal(5, piggy.Order);
            Assert.Equal("Some notes", piggy.Notes);
            Assert.Equal("5", piggy.ObjectGroupId);
            Assert.Equal("Example Group", piggy.ObjectGroupTitle);
            // percentage (12.5) is readOnly (private setter) and is not populated by the serializer.

            Assert.Equal("https://demo.firefly-iii.org/api/v1/piggy_banks/2", single.Data.Links.Self);
            Assert.Equal("self", single.Data.Links.Var0.Rel);
        }

        [Fact]
        public void PiggyBankSingle_With_Explicit_Nulls_Deserializes()
        {
            var single = JsonSerializer.Deserialize<PiggyBankSingle>(PiggyBankSingleNullsJson, SerializerOptions.Default);

            var piggy = single.Data.Attributes;
            Assert.Equal("Rainy day fund", piggy.Name);
            Assert.Equal("50.00", piggy.CurrentAmount);
            Assert.Null(piggy.TargetAmount);
            Assert.Null(piggy.TargetDate);
            Assert.Null(piggy.Notes);
            Assert.Null(piggy.ObjectGroupId);
            Assert.Null(piggy.ObjectGroupTitle);
            Assert.Equal(new DateTime(2018, 9, 17), piggy.StartDate);
        }

        [Fact]
        public void PiggyBankEventArray_Deserializes_Spec_Example()
        {
            var array = JsonSerializer.Deserialize<PiggyBankEventArray>(PiggyBankEventArrayJson, SerializerOptions.Default);

            Assert.Equal(2, array.Data.Count);
            Assert.Equal("piggy_bank_events", array.Data[0].Type);
            Assert.Equal("2", array.Data[0].Id);

            var addMoney = array.Data[0].Attributes;
            Assert.Equal("123.45", addMoney.Amount);
            Assert.Equal("4291", addMoney.TransactionJournalId);
            Assert.Equal("4291", addMoney.TransactionGroupId);
            Assert.Equal("EUR", addMoney.CurrencyCode);
            Assert.Equal(2, addMoney.CurrencyDecimalPlaces);
            // RFC3339 value with an offset is adjusted; compare in UTC to stay timezone-agnostic.
            Assert.Equal(new DateTime(2018, 9, 17, 11, 46, 47, DateTimeKind.Utc), addMoney.CreatedAt.ToUniversalTime());

            Assert.Equal("-123.45", array.Data[1].Attributes.Amount);

            Assert.Equal(2, array.Meta.Pagination.Total);
            Assert.Equal(1, array.Meta.Pagination.TotalPages);
            Assert.Equal("https://demo.firefly-iii.org/api/v1/piggy-banks/1/events?page=1", array.Links.Self);
        }
    }
}
