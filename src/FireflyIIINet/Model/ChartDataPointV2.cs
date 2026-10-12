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
    /// ChartDataPointV2
    /// </summary>
    [DataContract(Name = "ChartDataPointV2")]
    public partial class ChartDataPointV2 : IEquatable<ChartDataPointV2>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChartDataPointV2" /> class.
        /// </summary>
        /// <param name="key">The key is the label of the value, so for example: &#39;2018-01-01&#39; &#x3D;&gt; 13 or &#39;Groceries&#39; &#x3D;&gt; -123..</param>
        /// <param name="value">The value of the point, 13 or -123 in the examples of <paramref name="key"/>.</param>
        public ChartDataPointV2(string? key = default(string), decimal? value = default(decimal?))
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// The key is the label of the value, so for example: &#39;2018-01-01&#39; &#x3D;&gt; 13 or &#39;Groceries&#39; &#x3D;&gt; -123.
        /// </summary>
        /// <value>The key is the label of the value, so for example: &#39;2018-01-01&#39; &#x3D;&gt; 13 or &#39;Groceries&#39; &#x3D;&gt; -123.</value>
        /// <example>value</example>
        [DataMember(Name = "key", EmitDefaultValue = true)]
        [JsonPropertyName("key")]
        [System.Diagnostics.CodeAnalysis.AllowNull]
        public string Key { get; set; }

        /// <summary>
        /// The value of the point. Not a property of its own on the wire: a data set's entries
        /// arrive as an object of key and value pairs, which <see cref="FireflyIIINet.Client.ChartEntriesConverter{TPoint}"/>
        /// reads into points. Null when the server sends a null or a value that is not a number.
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = true)]
        [JsonPropertyName("value")]
        public decimal? Value { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ChartDataPointV2 {\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
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
            return Equals(input as ChartDataPointV2);
        }

        /// <summary>
        /// Returns true if ChartDataPointV2 instances are equal
        /// </summary>
        /// <param name="input">Instance of ChartDataPointV2 to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ChartDataPointV2 input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    Key == input.Key ||
					Key != null &&
					Key.Equals(input.Key)
                ) && 
                (
                    Value == input.Value
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
				if (Key != null)
				{
					hashCode = (hashCode * 59) + Key.GetHashCode();
				}
				hashCode = (hashCode * 59) + Value.GetHashCode();
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
