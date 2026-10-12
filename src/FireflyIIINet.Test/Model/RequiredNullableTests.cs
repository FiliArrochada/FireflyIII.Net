/*
 * Fields the specification lists as required but also "nullable: true": the key must be sent,
 * and null is a meaningful value (a piggy bank without a target, a recurrence without an end, a
 * rule action without an argument). The constructors used to reject null for them.
 */

using System;
using System.Text.Json;
using FireflyIIINet.Client;
using FireflyIIINet.Model;
using Xunit;

namespace FireflyIIINet.Test.Model
{
    public class RequiredNullableTests
    {
        [Fact]
        public void PiggyBank_Without_A_Target_Sends_Null()
        {
            var store = new PiggyBankStore(name: "Holiday", targetAmount: null, startDate: new DateTime(2026, 10, 1),
                accounts: new System.Collections.Generic.List<PiggyBankAccountStore> { new PiggyBankAccountStore(id: "1") });

            var json = JsonSerializer.Serialize(store, SerializerOptions.Default);

            Assert.Contains("\"target_amount\":null", json);
        }

        [Fact]
        public void Recurrence_Without_An_End_Sends_Null()
        {
            var store = new RecurrenceStore(type: RecurrenceTransactionType.Withdrawal, title: "Rent", firstDate: new DateTime(2026, 10, 1),
                repeatUntil: null,
                repetitions: new System.Collections.Generic.List<RecurrenceRepetitionStore>(),
                transactions: new System.Collections.Generic.List<RecurrenceTransactionStore>());

            var json = JsonSerializer.Serialize(store, SerializerOptions.Default);

            Assert.Contains("\"repeat_until\":null", json);
        }

        [Fact]
        public void Rule_Action_Without_A_Value_Sends_Null()
        {
            var action = new RuleActionStore(type: RuleActionKeyword.DeleteTransaction, value: null);

            var json = JsonSerializer.Serialize(action, SerializerOptions.Default);

            Assert.Contains("\"value\":null", json);
        }

        [Fact]
        public void Other_Required_Nullable_Fields_Accept_Null()
        {
            Assert.Null(new PiggyBankAccountStore(id: null).Id);
            Assert.Null(new PiggyBankProperties(name: "Holiday", targetAmount: null).TargetAmount);
            Assert.Null(new RuleAction(type: RuleActionKeyword.ClearCategory, value: null).Value);
        }
    }
}
