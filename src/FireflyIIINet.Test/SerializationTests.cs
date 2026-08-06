/*
 * Serialization tests validating the migration from Newtonsoft.Json to System.Text.Json.
 *
 * These exercise the behaviours most at risk in the migration:
 *   - enum values serialized/parsed via their [EnumMember] value (StringEnumMemberConverter)
 *   - explicit [JsonPropertyName] mapping (snake_case wire names)
 *   - EmitDefaultValue=false -> omit default; EmitDefaultValue=true -> always emit
 *     (including the TransactionSplitStore piggy bank fix: null must be emitted)
 *   - the PolymorphicProperty oneOf (bool | string | object | string[]) custom converter
 *   - date-only fields via OpenAPIDateConverter
 *   - deserialization through the protected [JsonConstructor] constructors
 */

using System;
using System.Collections.Generic;
using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test
{
    public class SerializationTests
    {
        private static readonly JsonSerializerOptions Options = SerializerOptions.Default;

        // ---------- Enums (EnumMember values) ----------

        [Fact]
        public void Enum_Serializes_Using_EnumMember_Value()
        {
            var account = new Account(name: "Checking", type: ShortAccountTypeProperty.Asset);
            var json = JsonSerializer.Serialize(account, Options);
            Assert.Contains("\"type\":\"asset\"", json);
            Assert.DoesNotContain("\"type\":1", json); // not the numeric underlying value
        }

        [Fact]
        public void Enum_Deserializes_From_EnumMember_Value()
        {
            var json = "{\"name\":\"Checking\",\"type\":\"asset\",\"account_role\":\"defaultAsset\"}";
            var account = JsonSerializer.Deserialize<Account>(json, Options);
            Assert.Equal(ShortAccountTypeProperty.Asset, account.Type);
            Assert.Equal(AccountRoleProperty.DefaultAsset, account.AccountRole);
        }

        // ---------- Property naming ----------

        [Fact]
        public void PropertyNames_Use_Snake_Case_Wire_Names()
        {
            var split = new TransactionSplitStore(
                type: TransactionTypeProperty.Withdrawal,
                date: new DateTime(2023, 5, 17, 12, 0, 0, DateTimeKind.Utc),
                amount: "12.50",
                description: "Lunch",
                sourceName: "Checking Account");
            var json = JsonSerializer.Serialize(split, Options);
            Assert.Contains("\"source_name\":\"Checking Account\"", json);
            Assert.Contains("\"type\":\"withdrawal\"", json);
        }

        // ---------- Default value handling ----------

        [Fact]
        public void EmitDefaultValueFalse_Omits_Null_Properties()
        {
            var account = new Account(name: "Checking", type: ShortAccountTypeProperty.Asset);
            var json = JsonSerializer.Serialize(account, Options);
            Assert.DoesNotContain("\"account_role\"", json); // EmitDefaultValue=false, unset
            Assert.DoesNotContain("\"iban\"", json);
        }

        [Fact]
        public void TransactionSplitStore_Emits_Null_PiggyBank_Properties()
        {
            // Manual fix carried over from the generated client: piggy_bank_id/piggy_bank_name
            // are EmitDefaultValue=true so an explicit null reaches the API on serialization.
            var split = new TransactionSplitStore(
                type: TransactionTypeProperty.Withdrawal,
                date: new DateTime(2023, 5, 17, 12, 0, 0, DateTimeKind.Utc),
                amount: "12.50",
                description: "Lunch");
            var json = JsonSerializer.Serialize(split, Options);
            Assert.Contains("\"piggy_bank_id\":null", json);
            Assert.Contains("\"piggy_bank_name\":null", json);
        }

        // ---------- PolymorphicProperty (oneOf: bool | string | object | string[]) ----------

        [Theory]
        [InlineData("{\"name\":\"currencyPreference\",\"data\":\"EUR\"}", typeof(string))]
        [InlineData("{\"name\":\"darkMode\",\"data\":true}", typeof(bool))]
        public void PolymorphicProperty_Deserializes_Primitives(string json, Type expected)
        {
            var pref = JsonSerializer.Deserialize<Preference>(json, Options);
            Assert.IsType(expected, pref.Data.ActualInstance);
        }

        [Fact]
        public void PolymorphicProperty_Deserializes_String_Array()
        {
            var pref = JsonSerializer.Deserialize<Preference>(
                "{\"name\":\"frontpageAccounts\",\"data\":[\"1\",\"2\"]}", Options);
            Assert.Equal(new List<string> { "1", "2" }, pref.Data.GetListString());
        }

        [Fact]
        public void PolymorphicProperty_RoundTrips_Bool()
        {
            var pref = new Preference(name: "darkMode", data: new PolymorphicProperty(true));
            var json = JsonSerializer.Serialize(pref, Options);
            Assert.Contains("\"data\":true", json);

            var back = JsonSerializer.Deserialize<Preference>(json, Options);
            Assert.True(back.Data.GetBool());
        }

        // ---------- Date-only fields ----------

        [Fact]
        public void DateOnly_Fields_Serialize_As_yyyy_MM_dd()
        {
            var budget = new AvailableBudgetStore(
                amount: "100.00",
                start: new DateTime(2023, 5, 1),
                end: new DateTime(2023, 5, 31));
            var json = JsonSerializer.Serialize(budget, Options);
            Assert.Contains("\"start\":\"2023-05-01\"", json);
            Assert.Contains("\"end\":\"2023-05-31\"", json);
        }

        [Fact]
        public void DateOnly_Fields_Deserialize_From_yyyy_MM_dd()
        {
            var budget = JsonSerializer.Deserialize<AvailableBudgetStore>(
                "{\"amount\":\"100.00\",\"start\":\"2023-05-01\",\"end\":\"2023-05-31\"}", Options);
            Assert.Equal(new DateTime(2023, 5, 1), budget.Start);
        }

        // ---------- Response envelope round-trip ----------

        [Fact]
        public void AccountSingle_Envelope_Deserializes()
        {
            var json = "{\"data\":{\"type\":\"accounts\",\"id\":\"2\",\"attributes\":{\"name\":\"Checking\",\"type\":\"asset\",\"active\":true}}}";
            var single = JsonSerializer.Deserialize<AccountSingle>(json, Options);
            Assert.Equal("2", single.Data.Id);
            Assert.Equal("Checking", single.Data.Attributes.Name);
        }
    }
}
