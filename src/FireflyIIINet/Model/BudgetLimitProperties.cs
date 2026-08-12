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
    /// BudgetLimitProperties
    /// </summary>
    [DataContract(Name = "BudgetLimitProperties")]
    public partial class BudgetLimitProperties : IEquatable<BudgetLimitProperties>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetLimitProperties" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected BudgetLimitProperties() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="BudgetLimitProperties" /> class.
        /// </summary>
        /// <param name="start">Start date of the budget limit..</param>
        /// <param name="end">End date of the budget limit..</param>
        /// <param name="currencyId">The currency ID of the currency associated with this object..</param>
        /// <param name="currencyName">The currency name of the currency associated with this object..</param>
        /// <param name="currencyCode">The currency code of the currency associated with this object..</param>
        /// <param name="amount">amount.</param>
        /// <param name="notes">Some notes for this specific budget limit..</param>
        public BudgetLimitProperties(DateTime? start = default(DateTime?), DateTime? end = default(DateTime?), string currencyId = default(string), string currencyName = default(string), string currencyCode = default(string), string amount = default(string), string notes = default(string))
        {
            Start = start ?? default(DateTime);
            End = end ?? default(DateTime);
            CurrencyId = currencyId;
            CurrencyName = currencyName;
            CurrencyCode = currencyCode;
            Amount = amount;
            Notes = notes;
        }

        /// <summary>
        /// Gets or Sets CreatedAt
        /// </summary>
        /// <example>2018-09-17T12:46:47+01:00</example>
        [DataMember(Name = "created_at", EmitDefaultValue = true)]
        [JsonPropertyName("created_at")]
        [JsonInclude]
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Returns false as CreatedAt should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeCreatedAt()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets UpdatedAt
        /// </summary>
        /// <example>2018-09-17T12:46:47+01:00</example>
        [DataMember(Name = "updated_at", EmitDefaultValue = true)]
        [JsonPropertyName("updated_at")]
        [JsonInclude]
        public DateTime UpdatedAt { get; private set; }

        /// <summary>
        /// Returns false as UpdatedAt should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeUpdatedAt()
        {
            return false;
        }
        /// <summary>
        /// Start date of the budget limit.
        /// </summary>
        /// <value>Start date of the budget limit.</value>
        /// <example>2018-09-17T12:46:47+01:00</example>
        [DataMember(Name = "start", EmitDefaultValue = true)]
        [JsonPropertyName("start")]
        public DateTime Start { get; set; }

        /// <summary>
        /// End date of the budget limit.
        /// </summary>
        /// <value>End date of the budget limit.</value>
        /// <example>2018-09-17T12:46:47+01:00</example>
        [DataMember(Name = "end", EmitDefaultValue = true)]
        [JsonPropertyName("end")]
        public DateTime End { get; set; }

        /// <summary>
        /// The budget ID of the associated budget.
        /// </summary>
        /// <value>The budget ID of the associated budget.</value>
        /// <example>23</example>
        [DataMember(Name = "budget_id", EmitDefaultValue = true)]
        [JsonPropertyName("budget_id")]
        [JsonInclude]
        public string BudgetId { get; private set; }

        /// <summary>
        /// Returns false as BudgetId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeBudgetId()
        {
            return false;
        }
        /// <summary>
        /// Indicates whether the object has a currency setting. If false, the object uses the administration&#39;s primary currency.
        /// </summary>
        /// <value>Indicates whether the object has a currency setting. If false, the object uses the administration&#39;s primary currency.</value>
        /// <example>true</example>
        [DataMember(Name = "object_has_currency_setting", EmitDefaultValue = true)]
        [JsonPropertyName("object_has_currency_setting")]
        [JsonInclude]
        public bool ObjectHasCurrencySetting { get; private set; }

        /// <summary>
        /// Returns false as ObjectHasCurrencySetting should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeObjectHasCurrencySetting()
        {
            return false;
        }
        /// <summary>
        /// The currency ID of the currency associated with this object.
        /// </summary>
        /// <value>The currency ID of the currency associated with this object.</value>
        /// <example>5</example>
        [DataMember(Name = "currency_id", EmitDefaultValue = true)]
        [JsonPropertyName("currency_id")]
        public string CurrencyId { get; set; }

        /// <summary>
        /// The currency name of the currency associated with this object.
        /// </summary>
        /// <value>The currency name of the currency associated with this object.</value>
        /// <example>Euro</example>
        [DataMember(Name = "currency_name", EmitDefaultValue = true)]
        [JsonPropertyName("currency_name")]
        public string CurrencyName { get; set; }

        /// <summary>
        /// The currency code of the currency associated with this object.
        /// </summary>
        /// <value>The currency code of the currency associated with this object.</value>
        /// <example>EUR</example>
        [DataMember(Name = "currency_code", EmitDefaultValue = true)]
        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or Sets CurrencySymbol
        /// </summary>
        /// <example>$</example>
        [DataMember(Name = "currency_symbol", EmitDefaultValue = true)]
        [JsonPropertyName("currency_symbol")]
        [JsonInclude]
        public string CurrencySymbol { get; private set; }

        /// <summary>
        /// Returns false as CurrencySymbol should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeCurrencySymbol()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets CurrencyDecimalPlaces
        /// </summary>
        /// <example>2</example>
        [DataMember(Name = "currency_decimal_places", EmitDefaultValue = true)]
        [JsonPropertyName("currency_decimal_places")]
        [JsonInclude]
        public int CurrencyDecimalPlaces { get; private set; }

        /// <summary>
        /// Returns false as CurrencyDecimalPlaces should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeCurrencyDecimalPlaces()
        {
            return false;
        }
        /// <summary>
        /// The currency ID of the administration&#39;s primary currency.
        /// </summary>
        /// <value>The currency ID of the administration&#39;s primary currency.</value>
        /// <example>5</example>
        [DataMember(Name = "primary_currency_id", EmitDefaultValue = true)]
        [JsonPropertyName("primary_currency_id")]
        [JsonInclude]
        public string PrimaryCurrencyId { get; private set; }

        /// <summary>
        /// Returns false as PrimaryCurrencyId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializePrimaryCurrencyId()
        {
            return false;
        }
        /// <summary>
        /// The currency name of the administration&#39;s primary currency.
        /// </summary>
        /// <value>The currency name of the administration&#39;s primary currency.</value>
        /// <example>Euro</example>
        [DataMember(Name = "primary_currency_name", EmitDefaultValue = true)]
        [JsonPropertyName("primary_currency_name")]
        [JsonInclude]
        public string PrimaryCurrencyName { get; private set; }

        /// <summary>
        /// Returns false as PrimaryCurrencyName should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializePrimaryCurrencyName()
        {
            return false;
        }
        /// <summary>
        /// The currency code of the administration&#39;s primary currency.
        /// </summary>
        /// <value>The currency code of the administration&#39;s primary currency.</value>
        /// <example>EUR</example>
        [DataMember(Name = "primary_currency_code", EmitDefaultValue = true)]
        [JsonPropertyName("primary_currency_code")]
        [JsonInclude]
        public string PrimaryCurrencyCode { get; private set; }

        /// <summary>
        /// Returns false as PrimaryCurrencyCode should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializePrimaryCurrencyCode()
        {
            return false;
        }
        /// <summary>
        /// The currency symbol of the administration&#39;s primary currency.
        /// </summary>
        /// <value>The currency symbol of the administration&#39;s primary currency.</value>
        /// <example>$</example>
        [DataMember(Name = "primary_currency_symbol", EmitDefaultValue = true)]
        [JsonPropertyName("primary_currency_symbol")]
        [JsonInclude]
        public string PrimaryCurrencySymbol { get; private set; }

        /// <summary>
        /// Returns false as PrimaryCurrencySymbol should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializePrimaryCurrencySymbol()
        {
            return false;
        }
        /// <summary>
        /// The currency decimal places of the administration&#39;s primary currency.
        /// </summary>
        /// <value>The currency decimal places of the administration&#39;s primary currency.</value>
        /// <example>2</example>
        [DataMember(Name = "primary_currency_decimal_places", EmitDefaultValue = true)]
        [JsonPropertyName("primary_currency_decimal_places")]
        [JsonInclude]
        public int PrimaryCurrencyDecimalPlaces { get; private set; }

        /// <summary>
        /// Returns false as PrimaryCurrencyDecimalPlaces should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializePrimaryCurrencyDecimalPlaces()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Amount
        /// </summary>
        /// <example>123.45</example>
        [DataMember(Name = "amount", EmitDefaultValue = true)]
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// The amount of this budget limit in the user&#39;s primary currency, if the original amount is in a different currency.
        /// </summary>
        /// <value>The amount of this budget limit in the user&#39;s primary currency, if the original amount is in a different currency.</value>
        /// <example>123.45</example>
        [DataMember(Name = "pc_amount", EmitDefaultValue = false)]
        [JsonPropertyName("pc_amount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonInclude]
        public string PcAmount { get; private set; }

        /// <summary>
        /// Returns false as PcAmount should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializePcAmount()
        {
            return false;
        }
        /// <summary>
        /// Period of the budget limit. Only used when auto-generated by auto-budget.
        /// </summary>
        /// <value>Period of the budget limit. Only used when auto-generated by auto-budget.</value>
        /// <example>monthly</example>
        [DataMember(Name = "period", EmitDefaultValue = false)]
        [JsonPropertyName("period")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonInclude]
        public string Period { get; private set; }

        /// <summary>
        /// Returns false as Period should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializePeriod()
        {
            return false;
        }
        /// <summary>
        /// Amount(s) spent in the currencies in the database for this budget limit.
        /// </summary>
        /// <value>Amount(s) spent in the currencies in the database for this budget limit.</value>
        [DataMember(Name = "spent", EmitDefaultValue = true)]
        [JsonPropertyName("spent")]
        [JsonInclude]
        public List<ArrayEntryWithCurrencyAndSum> Spent { get; private set; }

        /// <summary>
        /// Returns false as Spent should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeSpent()
        {
            return false;
        }
        /// <summary>
        /// Amount(s) spent in the primary currency in the database for this budget limit.
        /// </summary>
        /// <value>Amount(s) spent in the primary currency in the database for this budget limit.</value>
        [DataMember(Name = "pc_spent", EmitDefaultValue = true)]
        [JsonPropertyName("pc_spent")]
        [JsonInclude]
        public List<ArrayEntryWithCurrencyAndSum> PcSpent { get; private set; }

        /// <summary>
        /// Returns false as PcSpent should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializePcSpent()
        {
            return false;
        }
        /// <summary>
        /// Some notes for this specific budget limit.
        /// </summary>
        /// <value>Some notes for this specific budget limit.</value>
        /// <example>Some example notes</example>
        [DataMember(Name = "notes", EmitDefaultValue = false)]
        [JsonPropertyName("notes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Notes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class BudgetLimitProperties {\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Start: ").Append(Start).Append("\n");
            sb.Append("  End: ").Append(End).Append("\n");
            sb.Append("  BudgetId: ").Append(BudgetId).Append("\n");
            sb.Append("  ObjectHasCurrencySetting: ").Append(ObjectHasCurrencySetting).Append("\n");
            sb.Append("  CurrencyId: ").Append(CurrencyId).Append("\n");
            sb.Append("  CurrencyName: ").Append(CurrencyName).Append("\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  CurrencySymbol: ").Append(CurrencySymbol).Append("\n");
            sb.Append("  CurrencyDecimalPlaces: ").Append(CurrencyDecimalPlaces).Append("\n");
            sb.Append("  PrimaryCurrencyId: ").Append(PrimaryCurrencyId).Append("\n");
            sb.Append("  PrimaryCurrencyName: ").Append(PrimaryCurrencyName).Append("\n");
            sb.Append("  PrimaryCurrencyCode: ").Append(PrimaryCurrencyCode).Append("\n");
            sb.Append("  PrimaryCurrencySymbol: ").Append(PrimaryCurrencySymbol).Append("\n");
            sb.Append("  PrimaryCurrencyDecimalPlaces: ").Append(PrimaryCurrencyDecimalPlaces).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
            sb.Append("  PcAmount: ").Append(PcAmount).Append("\n");
            sb.Append("  Period: ").Append(Period).Append("\n");
            sb.Append("  Spent: ").Append(Spent).Append("\n");
            sb.Append("  PcSpent: ").Append(PcSpent).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
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
            return Equals(input as BudgetLimitProperties);
        }

        /// <summary>
        /// Returns true if BudgetLimitProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of BudgetLimitProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(BudgetLimitProperties input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    CreatedAt == input.CreatedAt ||
					CreatedAt.Equals(input.CreatedAt)
                ) &&
                (
                    UpdatedAt == input.UpdatedAt ||
					UpdatedAt.Equals(input.UpdatedAt)
                ) &&
                (
                    Start == input.Start ||
					Start.Equals(input.Start)
                ) &&
                (
                    End == input.End ||
					End.Equals(input.End)
                ) &&
                (
                    BudgetId == input.BudgetId ||
					BudgetId.Equals(input.BudgetId)
                ) &&
                (
                    ObjectHasCurrencySetting == input.ObjectHasCurrencySetting ||
                    ObjectHasCurrencySetting.Equals(input.ObjectHasCurrencySetting)
                ) &&
                (
                    CurrencyId == input.CurrencyId ||
					CurrencyId.Equals(input.CurrencyId)
                ) &&
                (
                    CurrencyName == input.CurrencyName ||
					CurrencyName.Equals(input.CurrencyName)
                ) &&
                (
                    CurrencyCode == input.CurrencyCode ||
					CurrencyCode.Equals(input.CurrencyCode)
                ) &&
                (
                    CurrencySymbol == input.CurrencySymbol ||
					CurrencySymbol.Equals(input.CurrencySymbol)
                ) &&
                (
                    CurrencyDecimalPlaces == input.CurrencyDecimalPlaces ||
                    CurrencyDecimalPlaces.Equals(input.CurrencyDecimalPlaces)
                ) &&
                (
                    PrimaryCurrencyId == input.PrimaryCurrencyId ||
                    (PrimaryCurrencyId != null &&
                    PrimaryCurrencyId.Equals(input.PrimaryCurrencyId))
                ) &&
                (
                    PrimaryCurrencyName == input.PrimaryCurrencyName ||
                    (PrimaryCurrencyName != null &&
                    PrimaryCurrencyName.Equals(input.PrimaryCurrencyName))
                ) &&
                (
                    PrimaryCurrencyCode == input.PrimaryCurrencyCode ||
                    (PrimaryCurrencyCode != null &&
                    PrimaryCurrencyCode.Equals(input.PrimaryCurrencyCode))
                ) &&
                (
                    PrimaryCurrencySymbol == input.PrimaryCurrencySymbol ||
                    (PrimaryCurrencySymbol != null &&
                    PrimaryCurrencySymbol.Equals(input.PrimaryCurrencySymbol))
                ) &&
                (
                    PrimaryCurrencyDecimalPlaces == input.PrimaryCurrencyDecimalPlaces ||
                    PrimaryCurrencyDecimalPlaces.Equals(input.PrimaryCurrencyDecimalPlaces)
                ) &&
                (
                    Amount == input.Amount ||
					Amount.Equals(input.Amount)
                ) &&
                (
                    PcAmount == input.PcAmount ||
                    (PcAmount != null &&
                    PcAmount.Equals(input.PcAmount))
                ) &&
                (
                    Period == input.Period ||
                    (Period != null &&
                    Period.Equals(input.Period))
                ) &&
                (
                    Spent == input.Spent ||
                    Spent != null &&
                    input.Spent != null &&
                    Spent.SequenceEqual(input.Spent)
                ) &&
                (
                    PcSpent == input.PcSpent ||
                    PcSpent != null &&
                    input.PcSpent != null &&
                    PcSpent.SequenceEqual(input.PcSpent)
                ) &&
                (
                    Notes == input.Notes ||
                    (Notes != null &&
                    Notes.Equals(input.Notes))
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
				hashCode = (hashCode * 59) + CreatedAt.GetHashCode();
				hashCode = (hashCode * 59) + UpdatedAt.GetHashCode();
				hashCode = (hashCode * 59) + Start.GetHashCode();
				hashCode = (hashCode * 59) + End.GetHashCode();
				hashCode = (hashCode * 59) + BudgetId.GetHashCode();
                hashCode = (hashCode * 59) + ObjectHasCurrencySetting.GetHashCode();
				hashCode = (hashCode * 59) + CurrencyId.GetHashCode();
				hashCode = (hashCode * 59) + CurrencyName.GetHashCode();
				hashCode = (hashCode * 59) + CurrencyCode.GetHashCode();
				hashCode = (hashCode * 59) + CurrencySymbol.GetHashCode();
                hashCode = (hashCode * 59) + CurrencyDecimalPlaces.GetHashCode();
                if (PrimaryCurrencyId != null)
                {
                    hashCode = (hashCode * 59) + PrimaryCurrencyId.GetHashCode();
                }
                if (PrimaryCurrencyName != null)
                {
                    hashCode = (hashCode * 59) + PrimaryCurrencyName.GetHashCode();
                }
                if (PrimaryCurrencyCode != null)
                {
                    hashCode = (hashCode * 59) + PrimaryCurrencyCode.GetHashCode();
                }
                if (PrimaryCurrencySymbol != null)
                {
                    hashCode = (hashCode * 59) + PrimaryCurrencySymbol.GetHashCode();
                }
                hashCode = (hashCode * 59) + PrimaryCurrencyDecimalPlaces.GetHashCode();
				hashCode = (hashCode * 59) + Amount.GetHashCode();
                if (PcAmount != null)
                {
                    hashCode = (hashCode * 59) + PcAmount.GetHashCode();
                }
                if (Period != null)
                {
                    hashCode = (hashCode * 59) + Period.GetHashCode();
                }
				hashCode = (hashCode * 59) + Spent.GetHashCode();
				hashCode = (hashCode * 59) + PcSpent.GetHashCode();
                if (Notes != null)
                {
                    hashCode = (hashCode * 59) + Notes.GetHashCode();
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
