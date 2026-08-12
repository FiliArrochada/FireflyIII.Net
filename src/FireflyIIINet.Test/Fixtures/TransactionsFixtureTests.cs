/*
 * Fixture tests: deserialization of realistic Transaction payloads built from the
 * example values in api/firefly-iii-6.4.0-v1.yaml (Transaction / TransactionSplit /
 * TransactionSplitStore schemas).
 *
 * Notes:
 *  - The read-side TransactionSplit schema in 6.4.0 has NO piggy_bank_id property;
 *    piggy_bank_id only exists on TransactionSplitStore/TransactionSplitUpdate.
 *    The explicit-null piggy bank coverage therefore targets TransactionSplitStore.
 *  - Read-only (private setter) properties such as user, transaction_journal_id and
 *    currency_symbol are included in the payloads but not asserted: System.Text.Json
 *    does not populate non-public setters without [JsonInclude].
 */

using System;
using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class TransactionsFixtureTests
    {
        private const string TransactionSingleJson = """
        {
          "data": {
            "type": "transactions",
            "id": "958",
            "attributes": {
              "created_at": "2018-09-17T12:46:47+01:00",
              "updated_at": "2018-09-17T12:46:47+01:00",
              "user": "3",
              "group_title": "Split transaction title.",
              "transactions": [
                {
                  "user": "3",
                  "transaction_journal_id": "10421",
                  "type": "withdrawal",
                  "date": "2018-09-17T12:46:47+01:00",
                  "order": 0,
                  "currency_id": "12",
                  "currency_code": "EUR",
                  "currency_symbol": "$",
                  "currency_name": "Euro",
                  "currency_decimal_places": 2,
                  "foreign_currency_id": null,
                  "foreign_currency_code": null,
                  "foreign_amount": null,
                  "amount": "123.45",
                  "description": "Vegetables",
                  "source_id": "2",
                  "source_name": "Checking account",
                  "source_iban": "NL02ABNA0123456789",
                  "source_type": "Asset account",
                  "destination_id": "5",
                  "destination_name": "Buy and Large",
                  "destination_iban": null,
                  "destination_type": "Expense account",
                  "budget_id": "4",
                  "budget_name": "Groceries",
                  "category_id": "43",
                  "category_name": "Groceries",
                  "bill_id": null,
                  "bill_name": null,
                  "reconciled": false,
                  "notes": "Some example notes",
                  "tags": ["Barbecue preparation"],
                  "internal_reference": null,
                  "external_id": null,
                  "external_url": null,
                  "recurrence_id": null,
                  "has_attachments": false
                },
                {
                  "user": "3",
                  "transaction_journal_id": "10422",
                  "type": "withdrawal",
                  "date": "2018-09-17T12:46:47+01:00",
                  "order": 1,
                  "currency_code": "EUR",
                  "amount": "12.50",
                  "description": "Fruit",
                  "source_id": "2",
                  "source_name": "Checking account",
                  "source_type": "Asset account",
                  "destination_id": "5",
                  "destination_name": "Buy and Large",
                  "destination_type": "Expense account",
                  "reconciled": false,
                  "notes": null,
                  "tags": null,
                  "has_attachments": false
                }
              ]
            }
          }
        }
        """;

        private const string TransactionArrayJson = """
        {
          "data": [
            {
              "type": "transactions",
              "id": "959",
              "attributes": {
                "created_at": "2018-09-17T12:46:47+01:00",
                "updated_at": "2018-09-17T12:46:47+01:00",
                "user": "3",
                "group_title": null,
                "transactions": [
                  {
                    "user": "3",
                    "transaction_journal_id": "10423",
                    "type": "deposit",
                    "date": "2018-09-17T12:46:47+01:00",
                    "order": 0,
                    "currency_code": "EUR",
                    "amount": "123.45",
                    "description": "Salary",
                    "source_id": "9",
                    "source_name": "Employer",
                    "source_type": "Revenue account",
                    "destination_id": "2",
                    "destination_name": "Checking account",
                    "destination_type": "Asset account",
                    "reconciled": true,
                    "tags": [],
                    "has_attachments": false
                  }
                ]
              }
            }
          ],
          "meta": {
            "pagination": {
              "total": 1,
              "count": 1,
              "per_page": 50,
              "current_page": 1,
              "total_pages": 1
            }
          }
        }
        """;

        // TransactionSplitStore payload with the piggy bank properties explicitly null
        // (the manual fix in the generated client keeps these EmitDefaultValue=true).
        private const string TransactionSplitStoreJson = """
        {
          "type": "withdrawal",
          "date": "2018-09-17T12:46:47+01:00",
          "amount": "123.45",
          "description": "Vegetables",
          "source_id": "2",
          "destination_id": "5",
          "category_name": "Groceries",
          "piggy_bank_id": null,
          "piggy_bank_name": null
        }
        """;

        [Fact]
        public void TransactionSingle_Deserializes_Spec_Example_With_Splits()
        {
            var single = JsonSerializer.Deserialize<TransactionSingle>(TransactionSingleJson, SerializerOptions.Default);

            Assert.NotNull(single);
            Assert.Equal("transactions", single.Data.Type);
            Assert.Equal("958", single.Data.Id);
            Assert.Equal("Split transaction title.", single.Data.Attributes.GroupTitle);
            Assert.Equal(2, single.Data.Attributes.Transactions.Count);

            var split = single.Data.Attributes.Transactions[0];
            Assert.Equal(TransactionTypeProperty.Withdrawal, split.Type);
            Assert.Equal(
                new DateTime(2018, 9, 17, 11, 46, 47, DateTimeKind.Utc),
                split.Date.ToUniversalTime());
            Assert.Equal("123.45", split.Amount);
            Assert.Equal("Vegetables", split.Description);
            Assert.Equal("EUR", split.CurrencyCode);
            Assert.Equal("2", split.SourceId);
            Assert.Equal(AccountTypeProperty.AssetAccount, split.SourceType);
            Assert.Equal("Buy and Large", split.DestinationName);
            Assert.Equal(AccountTypeProperty.ExpenseAccount, split.DestinationType);
            Assert.Equal("Groceries", split.CategoryName);
            Assert.False(split.Reconciled);
            Assert.Single(split.Tags);
            Assert.Equal("Barbecue preparation", split.Tags[0]);

            // nullable fields present as explicit null
            Assert.Null(split.ForeignAmount);
            Assert.Null(split.ForeignCurrencyId);
            Assert.Null(split.BillId);

            var secondSplit = single.Data.Attributes.Transactions[1];
            Assert.Equal("Fruit", secondSplit.Description);
            Assert.Null(secondSplit.Notes);
            Assert.Null(secondSplit.Tags);
        }

        [Fact]
        public void TransactionArray_Deserializes_Spec_Example()
        {
            var array = JsonSerializer.Deserialize<TransactionArray>(TransactionArrayJson, SerializerOptions.Default);

            Assert.NotNull(array);
            Assert.Single(array.Data);
            Assert.Equal("959", array.Data[0].Id);
            Assert.Null(array.Data[0].Attributes.GroupTitle);

            var split = Assert.Single(array.Data[0].Attributes.Transactions);
            Assert.Equal(TransactionTypeProperty.Deposit, split.Type);
            Assert.Equal(AccountTypeProperty.RevenueAccount, split.SourceType);
            Assert.Equal(AccountTypeProperty.AssetAccount, split.DestinationType);
            Assert.Equal("Salary", split.Description);
            Assert.True(split.Reconciled);
            Assert.Empty(split.Tags);

            Assert.Equal(1, array.Meta.Pagination.Total);
            Assert.Equal(1, array.Meta.Pagination.CurrentPage);
        }

        [Fact]
        public void TransactionSplitStore_PiggyBank_Explicit_Nulls_Deserialize()
        {
            var store = JsonSerializer.Deserialize<TransactionSplitStore>(TransactionSplitStoreJson, SerializerOptions.Default);

            Assert.NotNull(store);
            Assert.Equal(TransactionTypeProperty.Withdrawal, store.Type);
            Assert.Equal(
                new DateTime(2018, 9, 17, 11, 46, 47, DateTimeKind.Utc),
                store.Date.ToUniversalTime());
            Assert.Equal("123.45", store.Amount);
            Assert.Equal("Vegetables", store.Description);
            Assert.Null(store.PiggyBankId);
            Assert.Null(store.PiggyBankName);
        }
    }
}
