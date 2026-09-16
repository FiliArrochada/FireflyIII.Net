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
    /// The 200 body of GET /v1/search/transactions/count (6.7.0). The spec declares it inline
    /// (no named schema).
    /// </summary>
    [DataContract(Name = "TransactionCountResult")]
    public partial class TransactionCountResult : IEquatable<TransactionCountResult>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionCountResult" /> class.
        /// </summary>
        /// <param name="count">The number of matching transactions..</param>
        public TransactionCountResult(int? count = default(int?))
        {
            Count = count;
        }

        /// <summary>
        /// The number of matching transactions.
        /// </summary>
        /// <value>The number of matching transactions.</value>
        /// <example>42</example>
        [DataMember(Name = "count", EmitDefaultValue = true)]
        [JsonPropertyName("count")]
        public int? Count { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class TransactionCountResult {\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
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
            return Equals(input as TransactionCountResult);
        }

        /// <summary>
        /// Returns true if TransactionCountResult instances are equal
        /// </summary>
        /// <param name="input">Instance of TransactionCountResult to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TransactionCountResult input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    Count == input.Count ||
                    (Count != null &&
                    Count.Equals(input.Count))
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
                if (Count != null)
                {
                    hashCode = (hashCode * 59) + Count.GetHashCode();
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
