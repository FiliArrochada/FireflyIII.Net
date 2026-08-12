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
    /// PiggyBankUpdate
    /// </summary>
    [DataContract(Name = "PiggyBankUpdate")]
    public partial class PiggyBankUpdate : IEquatable<PiggyBankUpdate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PiggyBankUpdate" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PiggyBankUpdate() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PiggyBankUpdate" /> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="accounts">The accounts connected to this piggy bank..</param>
        /// <param name="targetAmount">targetAmount.</param>
        /// <param name="startDate">The date you started with this piggy bank..</param>
        /// <param name="targetDate">The date you intend to finish saving money..</param>
        /// <param name="order">order.</param>
        /// <param name="notes">notes.</param>
        /// <param name="objectGroupId">The group ID of the group this object is part of. NULL if no group..</param>
        /// <param name="objectGroupTitle">The name of the group. NULL if no group..</param>
        public PiggyBankUpdate(string name = default(string), List<PiggyBankAccountUpdate> accounts = default(List<PiggyBankAccountUpdate>), string targetAmount = default(string), DateTime? startDate = default(DateTime?), DateTime? targetDate = default(DateTime?), int order = default(int), string notes = default(string), string objectGroupId = default(string), string objectGroupTitle = default(string))
        {
            Name = name;
            Accounts = accounts;
            TargetAmount = targetAmount;
            StartDate = startDate ?? default(DateTime);
            TargetDate = targetDate;
            Order = order;
            Notes = notes;
            ObjectGroupId = objectGroupId;
            ObjectGroupTitle = objectGroupTitle;
        }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        /// <example>New digital camera</example>
        [DataMember(Name = "name", EmitDefaultValue = true)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The accounts connected to this piggy bank.
        /// </summary>
        /// <value>The accounts connected to this piggy bank.</value>
        [DataMember(Name = "accounts", EmitDefaultValue = true)]
        [JsonPropertyName("accounts")]
        public List<PiggyBankAccountUpdate> Accounts { get; set; }

        /// <summary>
        /// Gets or Sets CurrencyId
        /// </summary>
        /// <example>5</example>
        [DataMember(Name = "currency_id", EmitDefaultValue = true)]
        [JsonPropertyName("currency_id")]
        [JsonInclude]
        public string CurrencyId { get; private set; }

        /// <summary>
        /// Returns false as CurrencyId should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeCurrencyId()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets CurrencyCode
        /// </summary>
        /// <example>USD</example>
        [DataMember(Name = "currency_code", EmitDefaultValue = true)]
        [JsonPropertyName("currency_code")]
        [JsonInclude]
        public string CurrencyCode { get; private set; }

        /// <summary>
        /// Returns false as CurrencyCode should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeCurrencyCode()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets TargetAmount
        /// </summary>
        /// <example>123.45</example>
        [DataMember(Name = "target_amount", EmitDefaultValue = false)]
        [JsonPropertyName("target_amount")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string TargetAmount { get; set; }

        /// <summary>
        /// The date you started with this piggy bank.
        /// </summary>
        /// <value>The date you started with this piggy bank.</value>
        /// <example>Mon Sep 17 01:00:00 WEST 2018</example>
        [DataMember(Name = "start_date", EmitDefaultValue = true)]
        [JsonPropertyName("start_date")]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The date you intend to finish saving money.
        /// </summary>
        /// <value>The date you intend to finish saving money.</value>
        /// <example>Mon Sep 17 01:00:00 WEST 2018</example>
        [DataMember(Name = "target_date", EmitDefaultValue = false)]
        [JsonPropertyName("target_date")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonConverter(typeof(OpenAPIDateConverter))]
        public DateTime? TargetDate { get; set; }

        /// <summary>
        /// Gets or Sets Order
        /// </summary>
        /// <example>5</example>
        [DataMember(Name = "order", EmitDefaultValue = true)]
        [JsonPropertyName("order")]
        public int Order { get; set; }

        /// <summary>
        /// Gets or Sets Active
        /// </summary>
        /// <example>true</example>
        [DataMember(Name = "active", EmitDefaultValue = true)]
        [JsonPropertyName("active")]
        [JsonInclude]
        public bool Active { get; private set; }

        /// <summary>
        /// Returns false as Active should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeActive()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Notes
        /// </summary>
        /// <example>Some notes</example>
        [DataMember(Name = "notes", EmitDefaultValue = false)]
        [JsonPropertyName("notes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Notes { get; set; }

        /// <summary>
        /// The group ID of the group this object is part of. NULL if no group.
        /// </summary>
        /// <value>The group ID of the group this object is part of. NULL if no group.</value>
        /// <example>5</example>
        [DataMember(Name = "object_group_id", EmitDefaultValue = false)]
        [JsonPropertyName("object_group_id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ObjectGroupId { get; set; }

        /// <summary>
        /// The name of the group. NULL if no group.
        /// </summary>
        /// <value>The name of the group. NULL if no group.</value>
        /// <example>Example Group</example>
        [DataMember(Name = "object_group_title", EmitDefaultValue = false)]
        [JsonPropertyName("object_group_title")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ObjectGroupTitle { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class PiggyBankUpdate {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Accounts: ").Append(Accounts).Append("\n");
            sb.Append("  CurrencyId: ").Append(CurrencyId).Append("\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  TargetAmount: ").Append(TargetAmount).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  TargetDate: ").Append(TargetDate).Append("\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  ObjectGroupId: ").Append(ObjectGroupId).Append("\n");
            sb.Append("  ObjectGroupTitle: ").Append(ObjectGroupTitle).Append("\n");
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
            return Equals(input as PiggyBankUpdate);
        }

        /// <summary>
        /// Returns true if PiggyBankUpdate instances are equal
        /// </summary>
        /// <param name="input">Instance of PiggyBankUpdate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PiggyBankUpdate input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    Name == input.Name ||
					Name.Equals(input.Name)
                ) && 
                (
                    Accounts == input.Accounts ||
                    Accounts != null &&
                    input.Accounts != null &&
                    Accounts.SequenceEqual(input.Accounts)
                ) &&
                (
                    CurrencyId == input.CurrencyId ||
					CurrencyId.Equals(input.CurrencyId)
                ) && 
                (
                    CurrencyCode == input.CurrencyCode ||
					CurrencyCode.Equals(input.CurrencyCode)
                ) && 
                (
                    TargetAmount == input.TargetAmount ||
                    (TargetAmount != null &&
                    TargetAmount.Equals(input.TargetAmount))
                ) && 
                (
                    StartDate == input.StartDate ||
					StartDate.Equals(input.StartDate)
                ) && 
                (
                    TargetDate == input.TargetDate ||
                    (TargetDate != null &&
                    TargetDate.Equals(input.TargetDate))
                ) && 
                (
                    Order == input.Order ||
                    Order.Equals(input.Order)
                ) && 
                (
                    Active == input.Active ||
                    Active.Equals(input.Active)
                ) && 
                (
                    Notes == input.Notes ||
                    (Notes != null &&
                    Notes.Equals(input.Notes))
                ) && 
                (
                    ObjectGroupId == input.ObjectGroupId ||
                    (ObjectGroupId != null &&
                    ObjectGroupId.Equals(input.ObjectGroupId))
                ) && 
                (
                    ObjectGroupTitle == input.ObjectGroupTitle ||
                    (ObjectGroupTitle != null &&
                    ObjectGroupTitle.Equals(input.ObjectGroupTitle))
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
				hashCode = (hashCode * 59) + Name.GetHashCode();
                if (Accounts != null)
                {
                    hashCode = (hashCode * 59) + Accounts.GetHashCode();
                }
				hashCode = (hashCode * 59) + CurrencyId.GetHashCode();
				hashCode = (hashCode * 59) + CurrencyCode.GetHashCode();
                if (TargetAmount != null)
                {
                    hashCode = (hashCode * 59) + TargetAmount.GetHashCode();
                }
				hashCode = (hashCode * 59) + StartDate.GetHashCode();
                if (TargetDate != null)
                {
                    hashCode = (hashCode * 59) + TargetDate.GetHashCode();
                }
                hashCode = (hashCode * 59) + Order.GetHashCode();
                hashCode = (hashCode * 59) + Active.GetHashCode();
                if (Notes != null)
                {
                    hashCode = (hashCode * 59) + Notes.GetHashCode();
                }
                if (ObjectGroupId != null)
                {
                    hashCode = (hashCode * 59) + ObjectGroupId.GetHashCode();
                }
                if (ObjectGroupTitle != null)
                {
                    hashCode = (hashCode * 59) + ObjectGroupTitle.GetHashCode();
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
