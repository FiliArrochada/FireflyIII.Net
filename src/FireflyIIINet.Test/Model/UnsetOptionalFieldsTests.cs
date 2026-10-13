/*
 * Optional fields of request models must be left out when unset. They used to be sent as null
 * (or a DateTime as 0001-01-01), which the server rejects: an AccountStore without a currency id
 * failed with 422 "The currency id must be a number.", a TransactionLinkStore without a link type
 * name with "The selected link type name is invalid.".
 *
 * The sweep covers every [Body] type of the Refit interfaces and the models nested in them: a
 * key sent as null or 0001-01-01 must belong to a required property ([DataMember(IsRequired)],
 * which the server needs whatever its value) or to a field the spec marks nullable.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Refit;
using Xunit;

namespace FireflyIIINet.Test.Model
{
    public class UnsetOptionalFieldsTests
    {
        // Optional fields the spec marks nullable: null is a value the server accepts.
        private static readonly HashSet<string> SpecNullable = new HashSet<string>
        {
            "PiggyBankAccountUpdate.account_id",
            "TransactionSplitStore.piggy_bank_id",
            "TransactionSplitStore.piggy_bank_name",
        };

        public static IEnumerable<object[]> RequestModels()
        {
            var assembly = typeof(AccountStore).Assembly;
            var todo = new Stack<Type>(assembly.GetTypes()
                .Where(t => t.IsInterface && t.Namespace == "FireflyIIINet.Api")
                .SelectMany(t => t.GetMethods())
                .SelectMany(m => m.GetParameters())
                .Where(p => p.GetCustomAttribute<BodyAttribute>() != null)
                .Select(p => p.ParameterType));
            var seen = new HashSet<Type>();
            while (todo.Count > 0)
            {
                var type = todo.Pop();
                if (type.IsGenericType)
                {
                    foreach (var arg in type.GetGenericArguments()) todo.Push(arg);
                    continue;
                }
                // oneOf wrappers (PolymorphicProperty) serialize their inner value, not properties
                if (type.Namespace != "FireflyIIINet.Model" || !type.IsClass
                    || typeof(AbstractOpenAPISchema).IsAssignableFrom(type) || !seen.Add(type)) continue;
                foreach (var property in type.GetProperties()) todo.Push(property.PropertyType);
            }
            return seen.OrderBy(t => t.Name).Select(t => new object[] { t });
        }

        // The protected [JsonConstructor] when there is one, else the public ctor with its defaults.
        private static object CreateInstance(Type model)
        {
            if (model.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null) is { } parameterless)
            {
                return parameterless.Invoke(null);
            }
            var ctor = model.GetConstructors().OrderBy(c => c.GetParameters().Length).First();
            return ctor.Invoke(ctor.GetParameters().Select(p => p.HasDefaultValue ? p.DefaultValue : null).ToArray());
        }

        [Theory]
        [MemberData(nameof(RequestModels))]
        public void Unset_Optional_Fields_Are_Not_Sent(Type model)
        {
            var instance = CreateInstance(model);
            var required = model.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(p => p.GetCustomAttribute<DataMemberAttribute>()?.IsRequired == true)
                .Select(p => p.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name)
                .ToHashSet();

            using var json = JsonDocument.Parse(JsonSerializer.Serialize(instance, model, SerializerOptions.Default));
            var unsetButSent = json.RootElement.EnumerateObject()
                .Where(p => p.Value.ValueKind == JsonValueKind.Null
                            || (p.Value.ValueKind == JsonValueKind.String && p.Value.GetString()!.StartsWith("0001-01-01")))
                .Select(p => p.Name)
                .Where(name => !required.Contains(name) && !SpecNullable.Contains($"{model.Name}.{name}"))
                .ToList();

            Assert.True(unsetButSent.Count == 0, $"{model.Name} sends unset optional fields: {string.Join(", ", unsetButSent)}");
        }

        [Theory]
        [MemberData(nameof(RequestModels))]
        public void Default_Update_Sends_Only_Required_Fields(Type model)
        {
            // An update must not change what the caller did not set: a rename used to send
            // active:false (deactivating a budget, bill, recurrence, ...) and order:0.
            if (!model.Name.EndsWith("Update")) return;
            var instance = CreateInstance(model);
            var required = model.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(p => p.GetCustomAttribute<DataMemberAttribute>()?.IsRequired == true)
                .Select(p => p.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name)
                .ToHashSet();

            using var json = JsonDocument.Parse(JsonSerializer.Serialize(instance, model, SerializerOptions.Default));
            var unrequested = json.RootElement.EnumerateObject()
                .Select(p => p.Name)
                .Where(name => !required.Contains(name) && !SpecNullable.Contains($"{model.Name}.{name}"))
                .ToList();

            Assert.True(unrequested.Count == 0, $"{model.Name} sends fields nobody set: {string.Join(", ", unrequested)}");
        }

        [Fact]
        public void Update_Sends_Value_Fields_Only_When_Set()
        {
            Assert.Equal("{\"name\":\"Lunch\"}", JsonSerializer.Serialize(new BudgetUpdate("Lunch"), SerializerOptions.Default));
            Assert.Equal("{\"name\":\"Lunch\",\"active\":false,\"order\":0}",
                JsonSerializer.Serialize(new BudgetUpdate("Lunch", active: false, order: 0), SerializerOptions.Default));
            Assert.Equal("{\"title\":\"Groceries\",\"strict\":false}",
                JsonSerializer.Serialize(new RuleUpdate(title: "Groceries") { Strict = false }, SerializerOptions.Default));
        }

        [Fact]
        public void Store_Defaults_Match_The_Server()
        {
            // active defaults to true (the generated constructors said false, creating inactive
            // budgets, bills, rule groups and recurrences); order 0 is left for the server to
            // assign; a repetition's weekend defaults to 1 (the server rejects 0).
            Assert.Equal("{\"name\":\"Lunch\",\"active\":true,\"fire_webhooks\":true}",
                JsonSerializer.Serialize(new BudgetStore("Lunch"), SerializerOptions.Default));
            Assert.Equal("{\"title\":\"Groceries\",\"active\":true}",
                JsonSerializer.Serialize(new RuleGroupStore("Groceries"), SerializerOptions.Default));
            Assert.True(new BillStore(name: "Rent", amountMin: "1", amountMax: "1", date: new DateTime(2026, 10, 1), repeatFreq: BillRepeatFrequency.Monthly).Active);
            Assert.True(new RecurrenceStore(RecurrenceTransactionType.Withdrawal, "Rent", repetitions: new List<RecurrenceRepetitionStore>(), transactions: new List<RecurrenceTransactionStore>()).Active);
            Assert.Equal(1, new RecurrenceRepetitionStore(RecurrenceRepetitionType.Monthly, "1").Weekend);
            Assert.Contains("\"order\":3", JsonSerializer.Serialize(new RuleGroupStore("Groceries", order: 3), SerializerOptions.Default));
        }

        [Fact]
        public void PiggyBank_Store_Sends_What_The_Server_Reads()
        {
            // The server reads accounts[].account_id (the spec says id) and requires
            // transaction_currency_id or transaction_currency_code, which the spec omits.
            var store = new PiggyBankStore("Holiday", new List<PiggyBankAccountStore> { new PiggyBankAccountStore(id: "3") },
                targetAmount: "500", startDate: new DateTime(2026, 10, 1), transactionCurrencyCode: "EUR");

            var json = JsonSerializer.Serialize(store, SerializerOptions.Default);

            Assert.Contains("\"accounts\":[{\"account_id\":\"3\"}]", json);
            Assert.Contains("\"transaction_currency_code\":\"EUR\"", json);
            Assert.DoesNotContain("transaction_currency_id", json);
            Assert.DoesNotContain("\"order\"", json);
            Assert.DoesNotContain("\"active\"", json);
        }

        [Fact]
        public void Budget_Without_A_Currency_Deserializes()
        {
            // A budget created without a currency of its own: every currency field is null.
            const string json = """
            {"data":{"type":"budgets","id":"7","attributes":{"name":"Lunch","active":true,"order":5,
              "object_has_currency_setting":false,"currency_id":null,"currency_code":null,"currency_name":null,
              "currency_symbol":null,"currency_decimal_places":null,"primary_currency_id":"1",
              "primary_currency_code":"EUR","primary_currency_decimal_places":2,"spent":null,"pc_spent":null}}}
            """;

            var budget = JsonSerializer.Deserialize<BudgetSingle>(json, SerializerOptions.Default);

            Assert.Null(budget.Data.Attributes.CurrencyDecimalPlaces);
            Assert.Equal(2, budget.Data.Attributes.PrimaryCurrencyDecimalPlaces);
        }

        [Fact]
        public void AccountStore_Without_Currency_Sends_No_Currency_Keys()
        {
            var json = JsonSerializer.Serialize(new AccountStore("Checking", ShortAccountTypeProperty.Asset), SerializerOptions.Default);

            Assert.DoesNotContain("currency_id", json);
            Assert.DoesNotContain("currency_code", json);
            Assert.DoesNotContain("opening_balance", json);
            Assert.DoesNotContain("virtual_balance", json);
        }

        [Fact]
        public void TransactionLinkStore_With_Only_A_Link_Type_Id_Sends_No_Name()
        {
            var json = JsonSerializer.Serialize(new TransactionLinkStore("1", inwardId: "2", outwardId: "3"), SerializerOptions.Default);

            Assert.Contains("\"link_type_id\":\"1\"", json);
            Assert.DoesNotContain("link_type_name", json);
        }

        [Fact]
        public void BillStore_Without_End_Dates_Sends_No_Dates()
        {
            var json = JsonSerializer.Serialize(new BillStore(name: "Rent", amountMin: "100", amountMax: "100", date: new DateTime(2026, 10, 1), repeatFreq: BillRepeatFrequency.Monthly), SerializerOptions.Default);

            Assert.DoesNotContain("end_date", json);
            Assert.DoesNotContain("extension_date", json);
        }

        [Fact]
        public void Set_Optional_Fields_Are_Still_Sent()
        {
            var json = JsonSerializer.Serialize(new AccountStore("Checking", ShortAccountTypeProperty.Asset, currencyId: "12", currencyCode: "EUR"), SerializerOptions.Default);

            Assert.Contains("\"currency_id\":\"12\"", json);
            Assert.Contains("\"currency_code\":\"EUR\"", json);
        }
    }
}
