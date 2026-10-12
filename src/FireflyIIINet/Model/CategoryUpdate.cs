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
    /// CategoryUpdate
    /// </summary>
    [DataContract(Name = "CategoryUpdate")]
    public partial class CategoryUpdate : IEquatable<CategoryUpdate>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryUpdate" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected CategoryUpdate() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryUpdate" /> class.
        /// </summary>
        /// <param name="name">name (required).</param>
        /// <param name="notes">notes; null leaves them unchanged (assign <see cref="Notes"/> null to clear them).</param>
        /// <param name="color">The color of the category in HEX format; null leaves it unchanged (assign <see cref="Color"/> null to clear it).</param>
        public CategoryUpdate(string name = default(string), string? notes = default(string), string? color = default(string))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for CategoryUpdate and cannot be null");
            }
            Name = name;
            if (notes != null)
            {
                Notes = notes;
            }
            if (color != null)
            {
                Color = color;
            }
        }

        /// <summary>
        /// Gets or Sets Name. The server needs it on every update, although its spec marks it optional.
        /// </summary>
        /// <example>Lunch</example>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        // Notes and Color are three-state on the wire: never assigned = key omitted (the server keeps
        // the stored value), assigned null = "key": null (the server clears it), assigned a value =
        // sent. The public properties track assignment; the private *Wire properties serialize them.
        private string _notes;
        private bool _notesAssigned;
        private string _color;
        private bool _colorAssigned;

        /// <summary>
        /// Gets or Sets Notes. Assigning null clears the notes on the server; leaving it unassigned
        /// keeps them.
        /// </summary>
        /// <example>Some example notes</example>
        [DataMember(Name = "notes", EmitDefaultValue = false)]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.AllowNull]
        public string Notes
        {
            get => _notes;
            set { _notes = value; _notesAssigned = true; }
        }

        /// <summary>
        /// The color of the category in HEX format. Firefly III does not use this field, but your app might.
        /// Assigning null clears the color on the server; leaving it unassigned keeps it.
        /// </summary>
        /// <value>The color of the category in HEX format. Firefly III does not use this field, but your app might.</value>
        /// <example>FF0000</example>
        [DataMember(Name = "color", EmitDefaultValue = false)]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.AllowNull]
        public string Color
        {
            get => _color;
            set { _color = value; _colorAssigned = true; }
        }

        [JsonInclude]
        [JsonPropertyName("notes")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        private JsonElement? NotesWire
        {
            get => _notesAssigned ? JsonSerializer.SerializeToElement(_notes) : (JsonElement?)null;
            set => Notes = value is { ValueKind: JsonValueKind.String } v ? v.GetString() : null;
        }

        [JsonInclude]
        [JsonPropertyName("color")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        private JsonElement? ColorWire
        {
            get => _colorAssigned ? JsonSerializer.SerializeToElement(_color) : (JsonElement?)null;
            set => Color = value is { ValueKind: JsonValueKind.String } v ? v.GetString() : null;
        }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class CategoryUpdate {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Notes: ").Append(Notes).Append("\n");
            sb.Append("  Color: ").Append(Color).Append("\n");
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
            return Equals(input as CategoryUpdate);
        }

        /// <summary>
        /// Returns true if CategoryUpdate instances are equal
        /// </summary>
        /// <param name="input">Instance of CategoryUpdate to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CategoryUpdate input)
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
                    Notes == input.Notes ||
                    (Notes != null &&
                    Notes.Equals(input.Notes))
                ) &&
                (
                    Color == input.Color ||
                    (Color != null &&
                    Color.Equals(input.Color))
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
                if (Notes != null)
                {
                    hashCode = (hashCode * 59) + Notes.GetHashCode();
                }
                if (Color != null)
                {
                    hashCode = (hashCode * 59) + Color.GetHashCode();
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
