/*
 * Firefly III API
 *
 * This is the documentation of the Firefly III API. You can find accompanying documentation on the website of Firefly III itself (see below). Please report any bugs or issues.
 *
 * The pinned API version is recorded in FireflyIIINet.csproj and README.md.
 * Contact: james@firefly-iii.org
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = FireflyIIINet.Client.OpenAPIDateConverter;

namespace FireflyIIINet.Model
{
    /// <summary>
    /// CronResult — the body of GET /v1/cron/{cliToken}. Since Firefly III 6.7.0 the cron endpoint
    /// can run for every user (static cron token), so each job reports one CronResultRow per user
    /// instead of a single row; the telemetry job is gone and exchange rates, bill notifications
    /// and webhooks were added.
    /// </summary>
    [DataContract(Name = "CronResult")]
    public partial class CronResult : IEquatable<CronResult>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CronResult" /> class.
        /// </summary>
        /// <param name="recurringTransactions">recurringTransactions.</param>
        /// <param name="autoBudgets">autoBudgets.</param>
        /// <param name="exchangeRates">exchangeRates.</param>
        /// <param name="billNotifications">billNotifications.</param>
        /// <param name="webhooks">webhooks.</param>
        public CronResult(List<CronResultRow> recurringTransactions = default(List<CronResultRow>), List<CronResultRow> autoBudgets = default(List<CronResultRow>), List<CronResultRow> exchangeRates = default(List<CronResultRow>), List<CronResultRow> billNotifications = default(List<CronResultRow>), List<CronResultRow> webhooks = default(List<CronResultRow>))
        {
            RecurringTransactions = recurringTransactions;
            AutoBudgets = autoBudgets;
            ExchangeRates = exchangeRates;
            BillNotifications = billNotifications;
            Webhooks = webhooks;
        }

        /// <summary>
        /// Gets or Sets RecurringTransactions
        /// </summary>
        [DataMember(Name = "recurring_transactions", EmitDefaultValue = true)]
        [JsonPropertyName("recurring_transactions")]
        public List<CronResultRow> RecurringTransactions { get; set; }

        /// <summary>
        /// Gets or Sets AutoBudgets
        /// </summary>
        [DataMember(Name = "auto_budgets", EmitDefaultValue = true)]
        [JsonPropertyName("auto_budgets")]
        public List<CronResultRow> AutoBudgets { get; set; }

        /// <summary>
        /// Gets or Sets ExchangeRates
        /// </summary>
        [DataMember(Name = "exchange_rates", EmitDefaultValue = true)]
        [JsonPropertyName("exchange_rates")]
        public List<CronResultRow> ExchangeRates { get; set; }

        /// <summary>
        /// Gets or Sets BillNotifications
        /// </summary>
        [DataMember(Name = "bill_notifications", EmitDefaultValue = true)]
        [JsonPropertyName("bill_notifications")]
        public List<CronResultRow> BillNotifications { get; set; }

        /// <summary>
        /// Gets or Sets Webhooks
        /// </summary>
        [DataMember(Name = "webhooks", EmitDefaultValue = true)]
        [JsonPropertyName("webhooks")]
        public List<CronResultRow> Webhooks { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CronResult {\n");
            sb.Append("  RecurringTransactions: ").Append(RecurringTransactions).Append("\n");
            sb.Append("  AutoBudgets: ").Append(AutoBudgets).Append("\n");
            sb.Append("  ExchangeRates: ").Append(ExchangeRates).Append("\n");
            sb.Append("  BillNotifications: ").Append(BillNotifications).Append("\n");
            sb.Append("  Webhooks: ").Append(Webhooks).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return System.Text.Json.JsonSerializer.Serialize(this, FireflyIIINet.Client.SerializerOptions.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return Equals(input as CronResult);
        }

        /// <summary>
        /// Returns true if CronResult instances are equal
        /// </summary>
        /// <param name="input">Instance of CronResult to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CronResult input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    RecurringTransactions == input.RecurringTransactions ||
                    RecurringTransactions != null &&
                    input.RecurringTransactions != null &&
                    RecurringTransactions.SequenceEqual(input.RecurringTransactions)
                ) &&
                (
                    AutoBudgets == input.AutoBudgets ||
                    AutoBudgets != null &&
                    input.AutoBudgets != null &&
                    AutoBudgets.SequenceEqual(input.AutoBudgets)
                ) &&
                (
                    ExchangeRates == input.ExchangeRates ||
                    ExchangeRates != null &&
                    input.ExchangeRates != null &&
                    ExchangeRates.SequenceEqual(input.ExchangeRates)
                ) &&
                (
                    BillNotifications == input.BillNotifications ||
                    BillNotifications != null &&
                    input.BillNotifications != null &&
                    BillNotifications.SequenceEqual(input.BillNotifications)
                ) &&
                (
                    Webhooks == input.Webhooks ||
                    Webhooks != null &&
                    input.Webhooks != null &&
                    Webhooks.SequenceEqual(input.Webhooks)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (RecurringTransactions != null)
                {
                    hashCode = (hashCode * 59) + RecurringTransactions.GetHashCode();
                }
                if (AutoBudgets != null)
                {
                    hashCode = (hashCode * 59) + AutoBudgets.GetHashCode();
                }
                if (ExchangeRates != null)
                {
                    hashCode = (hashCode * 59) + ExchangeRates.GetHashCode();
                }
                if (BillNotifications != null)
                {
                    hashCode = (hashCode * 59) + BillNotifications.GetHashCode();
                }
                if (Webhooks != null)
                {
                    hashCode = (hashCode * 59) + Webhooks.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
