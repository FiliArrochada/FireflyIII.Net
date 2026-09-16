/*
 * Fixture tests for the autocomplete rows whose shape changed in Firefly III 6.7.0,
 * fed by the example payloads from the pinned v1 spec in api/:
 *   - AutocompleteTransactionWithMeta (GET /v1/autocomplete/transactions-with-meta, new)
 *   - AutocompleteAccount             (account_currency_* and active became required)
 */

using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Fixtures
{
    public class AutocompleteFixtureTests
    {
        [Fact]
        public void AutocompleteTransactionWithMeta_Deserializes_Spec_Example()
        {
            const string json = """
            {
              "id": "2",
              "transaction_group_id": "2",
              "name": "#12: Transaction",
              "description": "#12: Transaction",
              "date": "2026-09-01T00:00:00+00:00",
              "currency_code": "EUR",
              "amount": "123.45"
            }
            """;

            var row = JsonSerializer.Deserialize<AutocompleteTransactionWithMeta>(json, SerializerOptions.Default);

            Assert.Equal("2", row.Id);
            Assert.Equal("2", row.TransactionGroupId);
            Assert.Equal("#12: Transaction", row.Name);
            Assert.Equal("#12: Transaction", row.Description);
            Assert.NotNull(row.Date);
            Assert.Equal(new System.DateTime(2026, 9, 1), row.Date.Value.ToUniversalTime().Date);
            Assert.Equal("EUR", row.CurrencyCode);
            Assert.Equal("123.45", row.Amount); // amounts stay strings on the wire
        }

        [Fact]
        public void AutocompleteTransactionWithMeta_Tolerates_Missing_Optional_Fields()
        {
            const string json = """
            { "id": "3", "name": "#13: Rent", "description": "#13: Rent" }
            """;

            var row = JsonSerializer.Deserialize<AutocompleteTransactionWithMeta>(json, SerializerOptions.Default);

            Assert.Equal("3", row.Id);
            Assert.Null(row.TransactionGroupId);
            Assert.Null(row.Date);
            Assert.Null(row.CurrencyCode);
            Assert.Null(row.Amount);
        }

        [Fact]
        public void AutocompleteAccount_Deserializes_Spec_Example_With_Account_Currency()
        {
            const string json = """
            {
              "id": "2",
              "name": "Checking account",
              "name_with_balance": "Checking account (€ 1.234,56)",
              "active": true,
              "type": "Asset account",
              "currency_id": "12",
              "currency_name": "Euro",
              "currency_code": "EUR",
              "currency_symbol": "€",
              "currency_decimal_places": 2,
              "account_currency_id": "12",
              "account_currency_name": "Euro",
              "account_currency_code": "EUR",
              "account_currency_symbol": "€",
              "account_currency_decimal_places": 2
            }
            """;

            var account = JsonSerializer.Deserialize<AutocompleteAccount>(json, SerializerOptions.Default);

            Assert.Equal("2", account.Id);
            Assert.True(account.Active);
            Assert.Equal("EUR", account.CurrencyCode);
            Assert.Equal("EUR", account.AccountCurrencyCode);
            Assert.Equal(2, account.AccountCurrencyDecimalPlaces);
        }

        [Fact]
        public void AutocompleteAccount_Ctor_Requires_Account_Currency_Fields()
        {
            Assert.Throws<System.ArgumentNullException>(() => new AutocompleteAccount(
                id: "1", name: "A", nameWithBalance: "A (0)", type: "Asset account",
                currencyId: "1", currencyName: "Euro", currencyCode: "EUR", currencySymbol: "€", currencyDecimalPlaces: 2,
                accountCurrencyId: null, accountCurrencyName: "Euro", accountCurrencyCode: "EUR", accountCurrencySymbol: "€", accountCurrencyDecimalPlaces: 2,
                active: true));
        }
    }
}
