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
    /// AutocompleteTransactionWithMeta — one row of GET /v1/autocomplete/transactions-with-meta (6.7.0),
    /// the successor of the removed transactions-with-id endpoint.
    /// </summary>
    [DataContract(Name = "AutocompleteTransactionWithMeta")]
    public partial class AutocompleteTransactionWithMeta : IEquatable<AutocompleteTransactionWithMeta>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteTransactionWithMeta" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AutocompleteTransactionWithMeta() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteTransactionWithMeta" /> class.
        /// </summary>
        /// <param name="id">The ID of a transaction journal (basically a single split). (required).</param>
        /// <param name="transactionGroupId">The ID of the underlying transaction group..</param>
        /// <param name="name">Transaction description with ID in the name. (required).</param>
        /// <param name="description">Transaction description with ID in the name. (required).</param>
        /// <param name="date">Date of the transaction..</param>
        /// <param name="currencyCode">Currency code..</param>
        /// <param name="amount">The amount of the transaction, in the transaction&#39;s currency..</param>
        public AutocompleteTransactionWithMeta(string id = default(string), string transactionGroupId = default(string), string name = default(string), string description = default(string), DateTime? date = default(DateTime?), string currencyCode = default(string), string amount = default(string))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for AutocompleteTransactionWithMeta and cannot be null");
            }
            Id = id;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for AutocompleteTransactionWithMeta and cannot be null");
            }
            Name = name;
            // to ensure "description" is required (not null)
            if (description == null)
            {
                throw new ArgumentNullException("description is a required property for AutocompleteTransactionWithMeta and cannot be null");
            }
            Description = description;
            TransactionGroupId = transactionGroupId;
            Date = date;
            CurrencyCode = currencyCode;
            Amount = amount;
        }

        /// <summary>
        /// The ID of a transaction journal (basically a single split).
        /// </summary>
        /// <value>The ID of a transaction journal (basically a single split).</value>
        /// <example>2</example>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The ID of the underlying transaction group.
        /// </summary>
        /// <value>The ID of the underlying transaction group.</value>
        /// <example>2</example>
        [DataMember(Name = "transaction_group_id", EmitDefaultValue = true)]
        [JsonPropertyName("transaction_group_id")]
        public string TransactionGroupId { get; set; }

        /// <summary>
        /// Transaction description with ID in the name.
        /// </summary>
        /// <value>Transaction description with ID in the name.</value>
        /// <example>#12: Transaction</example>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Transaction description with ID in the name.
        /// </summary>
        /// <value>Transaction description with ID in the name.</value>
        /// <example>#12: Transaction</example>
        [DataMember(Name = "description", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Date of the transaction.
        /// </summary>
        /// <value>Date of the transaction.</value>
        /// <example>2026-09-01T00:00:00+00:00</example>
        [DataMember(Name = "date", EmitDefaultValue = true)]
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Currency code.
        /// </summary>
        /// <value>Currency code.</value>
        /// <example>EUR</example>
        [DataMember(Name = "currency_code", EmitDefaultValue = true)]
        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// The amount of the transaction, in the transaction&#39;s currency.
        /// </summary>
        /// <value>The amount of the transaction, in the transaction&#39;s currency.</value>
        /// <example>123.45</example>
        [DataMember(Name = "amount", EmitDefaultValue = true)]
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AutocompleteTransactionWithMeta {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  TransactionGroupId: ").Append(TransactionGroupId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Date: ").Append(Date).Append("\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  Amount: ").Append(Amount).Append("\n");
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
            return Equals(input as AutocompleteTransactionWithMeta);
        }

        /// <summary>
        /// Returns true if AutocompleteTransactionWithMeta instances are equal
        /// </summary>
        /// <param name="input">Instance of AutocompleteTransactionWithMeta to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AutocompleteTransactionWithMeta input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    Id == input.Id ||
                    (Id != null &&
                    Id.Equals(input.Id))
                ) &&
                (
                    TransactionGroupId == input.TransactionGroupId ||
                    (TransactionGroupId != null &&
                    TransactionGroupId.Equals(input.TransactionGroupId))
                ) &&
                (
                    Name == input.Name ||
                    (Name != null &&
                    Name.Equals(input.Name))
                ) &&
                (
                    Description == input.Description ||
                    (Description != null &&
                    Description.Equals(input.Description))
                ) &&
                (
                    Date == input.Date ||
                    (Date != null &&
                    Date.Equals(input.Date))
                ) &&
                (
                    CurrencyCode == input.CurrencyCode ||
                    (CurrencyCode != null &&
                    CurrencyCode.Equals(input.CurrencyCode))
                ) &&
                (
                    Amount == input.Amount ||
                    (Amount != null &&
                    Amount.Equals(input.Amount))
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
                if (Id != null)
                {
                    hashCode = (hashCode * 59) + Id.GetHashCode();
                }
                if (TransactionGroupId != null)
                {
                    hashCode = (hashCode * 59) + TransactionGroupId.GetHashCode();
                }
                if (Name != null)
                {
                    hashCode = (hashCode * 59) + Name.GetHashCode();
                }
                if (Description != null)
                {
                    hashCode = (hashCode * 59) + Description.GetHashCode();
                }
                if (Date != null)
                {
                    hashCode = (hashCode * 59) + Date.GetHashCode();
                }
                if (CurrencyCode != null)
                {
                    hashCode = (hashCode * 59) + CurrencyCode.GetHashCode();
                }
                if (Amount != null)
                {
                    hashCode = (hashCode * 59) + Amount.GetHashCode();
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
