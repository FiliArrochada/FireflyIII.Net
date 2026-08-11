/*
 * Firefly III API v2.0.5
 *
 * This is the documentation of the Firefly III API. You can find accompanying documentation on the website of Firefly III itself (see below). Please report any bugs or issues. You may use the \"Authorize\" button to try the API below. This file was last generated on 2023-08-06T04:35:40+00:00
 *
 * The version of the OpenAPI document: 2.0.5
 * Contact: james@firefly-iii.org
 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace FireflyIIINet.Model
{
    /// <summary>
    /// PolymorphicProperty
    /// </summary>
    [JsonConverter(typeof(PolymorphicPropertyJsonConverter))]
    [DataContract(Name = "PolymorphicProperty")]
    public partial class PolymorphicProperty : AbstractOpenAPISchema, IEquatable<PolymorphicProperty>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PolymorphicProperty" /> class
        /// with the <see cref="bool" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of bool.</param>
        public PolymorphicProperty(bool actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolymorphicProperty" /> class
        /// with the <see cref="string" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of string.</param>
        public PolymorphicProperty(string actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolymorphicProperty" /> class
        /// with the <see cref="Object" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of Object.</param>
        public PolymorphicProperty(Object actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PolymorphicProperty" /> class
        /// with the <see cref="List{String}" /> class
        /// </summary>
        /// <param name="actualInstance">An instance of List&lt;string&gt;.</param>
        public PolymorphicProperty(List<string> actualInstance)
        {
            this.IsNullable = false;
            this.SchemaType= "oneOf";
            this.ActualInstance = actualInstance ?? throw new ArgumentException("Invalid instance found. Must not be null.");
        }


        private Object _actualInstance;

        /// <summary>
        /// Gets or Sets ActualInstance
        /// </summary>
        public override Object ActualInstance
        {
            get
            {
                return _actualInstance;
            }
            set
            {
                if (value.GetType() == typeof(List<string>))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(bool))
                {
                    this._actualInstance = value;
                }
                else if (value.GetType() == typeof(string))
                {
                    this._actualInstance = value;
                }
                else if (value != null)
                {
                    this._actualInstance = value;
                }
                else
                {
                    throw new ArgumentException("Invalid instance found. Must be the following types: List<string>, Object, bool, string");
                }
            }
        }

        /// <summary>
        /// Get the actual instance of `bool`. If the actual instance is not `bool`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of bool</returns>
        public bool GetBool()
        {
            return (bool)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `string`. If the actual instance is not `string`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of string</returns>
        public string GetString()
        {
            return (string)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `Object`. If the actual instance is not `Object`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of Object</returns>
        public Object GetObject()
        {
            return (Object)this.ActualInstance;
        }

        /// <summary>
        /// Get the actual instance of `List&lt;string&gt;`. If the actual instance is not `List&lt;string&gt;`,
        /// the InvalidClassException will be thrown
        /// </summary>
        /// <returns>An instance of List&lt;string&gt;</returns>
        public List<string> GetListString()
        {
            return (List<string>)this.ActualInstance;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PolymorphicProperty {\n");
            sb.Append("  ActualInstance: ").Append(this.ActualInstance).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public override string ToJson()
        {
            return JsonSerializer.Serialize(this.ActualInstance, PolymorphicProperty.SerializerSettings);
        }

        /// <summary>
        /// Converts the JSON string into an instance of PolymorphicProperty
        /// </summary>
        /// <param name="jsonString">JSON string</param>
        /// <returns>An instance of PolymorphicProperty</returns>
        public static PolymorphicProperty FromJson(string jsonString)
        {
            if (string.IsNullOrEmpty(jsonString))
            {
                return null;
            }

            using (var doc = JsonDocument.Parse(jsonString))
            {
                return FromJsonElement(doc.RootElement);
            }
        }

        /// <summary>
        /// Converts a parsed <see cref="JsonElement" /> into an instance of PolymorphicProperty.
        /// The oneOf candidate (bool, string, List&lt;string&gt; or Object) is picked by the
        /// JSON token kind, so each payload maps to exactly one candidate.
        /// </summary>
        /// <param name="element">Parsed JSON element</param>
        /// <returns>An instance of PolymorphicProperty</returns>
        internal static PolymorphicProperty FromJsonElement(JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Null:
                    return null;
                case JsonValueKind.True:
                case JsonValueKind.False:
                    return new PolymorphicProperty(element.GetBoolean());
                case JsonValueKind.String:
                    return new PolymorphicProperty(element.GetString());
                case JsonValueKind.Array:
                    try
                    {
                        return new PolymorphicProperty(JsonSerializer.Deserialize<List<string>>(element.GetRawText(), PolymorphicProperty.SerializerSettings));
                    }
                    catch (JsonException)
                    {
                        // Not an array of strings: fall back to the Object candidate.
                        return new PolymorphicProperty(JsonSerializer.Deserialize<Object>(element.GetRawText(), PolymorphicProperty.AdditionalPropertiesSerializerSettings));
                    }
                case JsonValueKind.Object:
                case JsonValueKind.Number:
                    return new PolymorphicProperty(JsonSerializer.Deserialize<Object>(element.GetRawText(), PolymorphicProperty.AdditionalPropertiesSerializerSettings));
                default:
                    throw new InvalidDataException("The JSON string `" + element.GetRawText() + "` cannot be deserialized into any schema defined.");
            }
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as PolymorphicProperty);
        }

        /// <summary>
        /// Returns true if PolymorphicProperty instances are equal
        /// </summary>
        /// <param name="input">Instance of PolymorphicProperty to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PolymorphicProperty input)
        {
            if (input == null)
                return false;

            return this.ActualInstance.Equals(input.ActualInstance);
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
                if (this.ActualInstance != null)
                    hashCode = hashCode * 59 + this.ActualInstance.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

    /// <summary>
    /// Custom JSON converter for PolymorphicProperty
    /// </summary>
    public class PolymorphicPropertyJsonConverter : JsonConverter<PolymorphicProperty>
    {
        /// <summary>
        /// To write the JSON string
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">Object to be converted into a JSON string</param>
        /// <param name="options">Serializer options</param>
        public override void Write(Utf8JsonWriter writer, PolymorphicProperty value, JsonSerializerOptions options)
        {
            writer.WriteRawValue(value.ToJson());
        }

        /// <summary>
        /// To convert a JSON string into an object
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="typeToConvert">Type to convert (Read) — unused</param>
        /// <param name="options">Serializer options</param>
        /// <returns>The object converted from the JSON string</returns>
        public override PolymorphicProperty Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.Null)
            {
                using (var doc = JsonDocument.ParseValue(ref reader))
                {
                    return PolymorphicProperty.FromJsonElement(doc.RootElement);
                }
            }
            return null;
        }
    }

}
