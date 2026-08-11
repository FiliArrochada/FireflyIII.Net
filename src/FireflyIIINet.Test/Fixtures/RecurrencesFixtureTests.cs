/*
 * Fixture tests for the Recurrences area, fed by the example payloads from the
 * Firefly III OpenAPI spec (api/firefly-iii-2.0.9-v1.yaml, Recurrence* schemas).
 *
 * Note: read-only spec fields (created_at, updated_at, latest_date, repetition id /
 * description / occurrences, currency_symbol, ...) map onto private-setter properties
 * and are intentionally present in the payloads only to prove they deserialize without
 * error; assertions target the publicly settable properties.
 */

using System;
using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class RecurrencesFixtureTests
    {
        private const string RecurrenceSingleJson = """
        {
          "data": {
            "type": "recurrences",
            "id": "2",
            "attributes": {
              "created_at": "2018-09-17T12:46:47+01:00",
              "updated_at": "2018-09-17T12:46:47+01:00",
              "type": "withdrawal",
              "title": "Rent",
              "description": "Recurring transaction for the monthly rent",
              "first_date": "2018-09-17",
              "latest_date": null,
              "repeat_until": null,
              "nr_of_repetitions": 5,
              "apply_rules": true,
              "active": true,
              "notes": "Some notes",
              "repetitions": [
                {
                  "id": "2",
                  "created_at": "2018-09-17T12:46:47+01:00",
                  "updated_at": "2018-09-17T12:46:47+01:00",
                  "type": "monthly",
                  "moment": "3",
                  "skip": 0,
                  "weekend": 1,
                  "description": "Every month on the 3rd day",
                  "occurrences": ["2021-11-03T00:00:00+01:00", "2021-12-03T00:00:00+01:00"]
                }
              ],
              "transactions": [
                {
                  "description": "Rent for the current month",
                  "amount": "123.45",
                  "foreign_amount": null,
                  "currency_id": "3",
                  "currency_code": "EUR",
                  "currency_symbol": "€",
                  "currency_decimal_places": 2,
                  "foreign_currency_id": null,
                  "budget_id": "4",
                  "category_id": "211",
                  "category_name": "Bills",
                  "source_id": "913",
                  "source_name": "Checking account",
                  "source_iban": "NL02ABNA0123456789",
                  "source_type": "Asset account",
                  "destination_id": "258",
                  "destination_name": "Buy and Large",
                  "destination_iban": null,
                  "destination_type": "Expense account",
                  "tags": null,
                  "piggy_bank_id": null,
                  "piggy_bank_name": null
                }
              ]
            },
            "links": {
              "self": "https://demo.firefly-iii.org/api/v1/recurrences/2"
            }
          }
        }
        """;

        [Fact]
        public void RecurrenceSingle_Deserializes_Spec_Example()
        {
            var single = JsonSerializer.Deserialize<RecurrenceSingle>(RecurrenceSingleJson, SerializerOptions.Default);

            Assert.Equal("recurrences", single.Data.Type);
            Assert.Equal("2", single.Data.Id);

            var recurrence = single.Data.Attributes;
            Assert.Equal(RecurrenceTransactionType.Withdrawal, recurrence.Type);
            Assert.Equal("Rent", recurrence.Title);
            Assert.Equal("Recurring transaction for the monthly rent", recurrence.Description);
            Assert.Equal(new DateTime(2018, 9, 17), recurrence.FirstDate);
            Assert.Null(recurrence.RepeatUntil);
            Assert.Equal(5, recurrence.NrOfRepetitions);
            Assert.True(recurrence.ApplyRules);
            Assert.True(recurrence.Active);
            Assert.Equal("Some notes", recurrence.Notes);
        }

        [Fact]
        public void RecurrenceSingle_Maps_Repetitions_And_Transactions_Arrays()
        {
            var single = JsonSerializer.Deserialize<RecurrenceSingle>(RecurrenceSingleJson, SerializerOptions.Default);
            var recurrence = single.Data.Attributes;

            var repetition = Assert.Single(recurrence.Repetitions);
            Assert.Equal(RecurrenceRepetitionType.Monthly, repetition.Type);
            Assert.Equal("3", repetition.Moment);
            Assert.Equal(0, repetition.Skip);
            Assert.Equal(1, repetition.Weekend);

            var transaction = Assert.Single(recurrence.Transactions);
            Assert.Equal("Rent for the current month", transaction.Description);
            Assert.Equal("123.45", transaction.Amount);
            Assert.Equal("EUR", transaction.CurrencyCode);
            Assert.Equal(AccountTypeProperty.AssetAccount, transaction.SourceType);
            Assert.Equal(AccountTypeProperty.ExpenseAccount, transaction.DestinationType);
            Assert.Null(transaction.PiggyBankId);
            Assert.Null(transaction.ForeignAmount);
        }

        [Fact]
        public void Recurrence_With_RepeatUntil_And_Null_NrOfRepetitions_Deserializes()
        {
            const string json = """
            {
              "type": "transfer",
              "title": "Savings",
              "description": "Recurring monthly transfer to savings",
              "first_date": "2018-09-17",
              "repeat_until": "2021-09-17",
              "nr_of_repetitions": null,
              "apply_rules": false,
              "active": true,
              "notes": null,
              "repetitions": [],
              "transactions": []
            }
            """;

            var recurrence = JsonSerializer.Deserialize<Recurrence>(json, SerializerOptions.Default);

            Assert.Equal(RecurrenceTransactionType.Transfer, recurrence.Type);
            Assert.Equal(new DateTime(2021, 9, 17), recurrence.RepeatUntil);
            Assert.Null(recurrence.NrOfRepetitions);
            Assert.Null(recurrence.Notes);
            Assert.Empty(recurrence.Repetitions);
            Assert.Empty(recurrence.Transactions);
        }

        [Theory]
        [InlineData("daily", RecurrenceRepetitionType.Daily)]
        [InlineData("weekly", RecurrenceRepetitionType.Weekly)]
        [InlineData("ndom", RecurrenceRepetitionType.Ndom)]
        [InlineData("monthly", RecurrenceRepetitionType.Monthly)]
        [InlineData("yearly", RecurrenceRepetitionType.Yearly)]
        public void RecurrenceRepetition_Type_Maps_All_Wire_Values(string wireValue, RecurrenceRepetitionType expected)
        {
            var json = $$"""{ "type": "{{wireValue}}", "moment": "3", "skip": 0, "weekend": 1 }""";
            var repetition = JsonSerializer.Deserialize<RecurrenceRepetition>(json, SerializerOptions.Default);
            Assert.Equal(expected, repetition.Type);
        }
    }
}
