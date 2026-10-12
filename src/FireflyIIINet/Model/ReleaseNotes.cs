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
    /// The 200 body of GET /v1/release-notes/{version} (6.7.8). Both note fields are null when the
    /// server has no notes for the requested version. The wire field release_notes maps to
    /// <see cref="ReleaseNotesHtml"/> because a member cannot share its type's name.
    /// </summary>
    [DataContract(Name = "ReleaseNotes")]
    public partial class ReleaseNotes : IEquatable<ReleaseNotes>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReleaseNotes" /> class.
        /// </summary>
        /// <param name="version">The version the notes belong to, without a leading "v"..</param>
        /// <param name="releaseNotesHtml">The release notes as HTML..</param>
        /// <param name="releaseNotesMarkdown">The release notes in Markdown format..</param>
        public ReleaseNotes(string? version = default(string), string? releaseNotesHtml = default(string), string? releaseNotesMarkdown = default(string))
        {
            Version = version;
            ReleaseNotesHtml = releaseNotesHtml;
            ReleaseNotesMarkdown = releaseNotesMarkdown;
        }

        /// <summary>
        /// The version the notes belong to, without a leading "v".
        /// </summary>
        /// <value>The version the notes belong to, without a leading "v".</value>
        /// <example>6.7.8</example>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        [JsonPropertyName("version")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [System.Diagnostics.CodeAnalysis.AllowNull]
        public string Version { get; set; }

        /// <summary>
        /// The release notes as HTML.
        /// </summary>
        /// <value>The release notes as HTML.</value>
        [DataMember(Name = "release_notes", EmitDefaultValue = true)]
        [JsonPropertyName("release_notes")]
        [System.Diagnostics.CodeAnalysis.AllowNull]
        public string ReleaseNotesHtml { get; set; }

        /// <summary>
        /// The release notes in Markdown format.
        /// </summary>
        /// <value>The release notes in Markdown format.</value>
        [DataMember(Name = "release_notes_markdown", EmitDefaultValue = true)]
        [JsonPropertyName("release_notes_markdown")]
        [System.Diagnostics.CodeAnalysis.AllowNull]
        public string ReleaseNotesMarkdown { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ReleaseNotes {\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  ReleaseNotesHtml: ").Append(ReleaseNotesHtml).Append("\n");
            sb.Append("  ReleaseNotesMarkdown: ").Append(ReleaseNotesMarkdown).Append("\n");
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
            return Equals(input as ReleaseNotes);
        }

        /// <summary>
        /// Returns true if ReleaseNotes instances are equal
        /// </summary>
        /// <param name="input">Instance of ReleaseNotes to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ReleaseNotes input)
        {
            if (input == null)
            {
                return false;
            }
            return
                (
                    Version == input.Version ||
                    (Version != null &&
                    Version.Equals(input.Version))
                ) &&
                (
                    ReleaseNotesHtml == input.ReleaseNotesHtml ||
                    (ReleaseNotesHtml != null &&
                    ReleaseNotesHtml.Equals(input.ReleaseNotesHtml))
                ) &&
                (
                    ReleaseNotesMarkdown == input.ReleaseNotesMarkdown ||
                    (ReleaseNotesMarkdown != null &&
                    ReleaseNotesMarkdown.Equals(input.ReleaseNotesMarkdown))
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
                if (Version != null)
                {
                    hashCode = (hashCode * 59) + Version.GetHashCode();
                }
                if (ReleaseNotesHtml != null)
                {
                    hashCode = (hashCode * 59) + ReleaseNotesHtml.GetHashCode();
                }
                if (ReleaseNotesMarkdown != null)
                {
                    hashCode = (hashCode * 59) + ReleaseNotesMarkdown.GetHashCode();
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
