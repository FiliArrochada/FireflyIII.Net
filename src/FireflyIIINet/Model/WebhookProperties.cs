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
    /// WebhookProperties
    /// </summary>
    [DataContract(Name = "WebhookProperties")]
    public partial class WebhookProperties : IEquatable<WebhookProperties>, IValidatableObject
    {

        /// <summary>
        /// Gets or Sets Triggers
        /// </summary>
        [DataMember(Name = "triggers", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("triggers")]
        public List<WebhookTrigger> Triggers { get; set; }

        /// <summary>
        /// Gets or Sets Responses
        /// </summary>
        [DataMember(Name = "responses", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("responses")]
        public List<WebhookResponse> Responses { get; set; }

        /// <summary>
        /// Gets or Sets Deliveries
        /// </summary>
        [DataMember(Name = "deliveries", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("deliveries")]
        public List<WebhookDelivery> Deliveries { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookProperties" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected WebhookProperties() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookProperties" /> class.
        /// </summary>
        /// <param name="active">Boolean to indicate if the webhook is active.</param>
        /// <param name="title">A title for the webhook for easy recognition. (required).</param>
        /// <param name="triggers">triggers (required).</param>
        /// <param name="responses">responses (required).</param>
        /// <param name="deliveries">deliveries (required).</param>
        /// <param name="url">The URL of the webhook. Has to start with &#x60;https&#x60;. (required).</param>
        public WebhookProperties(bool active = default(bool), string title = default(string), List<WebhookTrigger> triggers = default(List<WebhookTrigger>), List<WebhookResponse> responses = default(List<WebhookResponse>), List<WebhookDelivery> deliveries = default(List<WebhookDelivery>), string url = default(string))
        {
            // to ensure "title" is required (not null)
            if (title == null)
            {
                throw new ArgumentNullException("title is a required property for WebhookProperties and cannot be null");
            }
            Title = title;
            // to ensure "triggers" is required (not null)
            if (triggers == null)
            {
                throw new ArgumentNullException("triggers is a required property for WebhookProperties and cannot be null");
            }
            Triggers = triggers;
            // to ensure "responses" is required (not null)
            if (responses == null)
            {
                throw new ArgumentNullException("responses is a required property for WebhookProperties and cannot be null");
            }
            Responses = responses;
            // to ensure "deliveries" is required (not null)
            if (deliveries == null)
            {
                throw new ArgumentNullException("deliveries is a required property for WebhookProperties and cannot be null");
            }
            Deliveries = deliveries;
            // to ensure "url" is required (not null)
            if (url == null)
            {
                throw new ArgumentNullException("url is a required property for WebhookProperties and cannot be null");
            }
            Url = url;
            Active = active;
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
        /// Boolean to indicate if the webhook is active
        /// </summary>
        /// <value>Boolean to indicate if the webhook is active</value>
        /// <example>false</example>
        [DataMember(Name = "active", EmitDefaultValue = true)]
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        /// A title for the webhook for easy recognition.
        /// </summary>
        /// <value>A title for the webhook for easy recognition.</value>
        /// <example>Update magic mirror on new transaction</example>
        [DataMember(Name = "title", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// A 24-character secret for the webhook. It&#39;s generated by Firefly III when saving a new webhook. If you submit a new secret through the PUT endpoint it will generate a new secret for the selected webhook, a new secret bearing no relation to whatever you just submitted.
        /// </summary>
        /// <value>A 24-character secret for the webhook. It&#39;s generated by Firefly III when saving a new webhook. If you submit a new secret through the PUT endpoint it will generate a new secret for the selected webhook, a new secret bearing no relation to whatever you just submitted.</value>
        /// <example>iMLZLtLx2JHWhK9Dtyuoqyir</example>
        [DataMember(Name = "secret", EmitDefaultValue = true)]
        [JsonPropertyName("secret")]
        [JsonInclude]
        public string Secret { get; private set; }

        /// <summary>
        /// Returns false as Secret should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeSecret()
        {
            return false;
        }
        /// <summary>
        /// The URL of the webhook. Has to start with &#x60;https&#x60;.
        /// </summary>
        /// <value>The URL of the webhook. Has to start with &#x60;https&#x60;.</value>
        /// <example>https://example.com</example>
        [DataMember(Name = "url", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class WebhookProperties {\n");
            sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
            sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  Secret: ").Append(Secret).Append("\n");
            sb.Append("  Triggers: ").Append(Triggers).Append("\n");
            sb.Append("  Responses: ").Append(Responses).Append("\n");
            sb.Append("  Deliveries: ").Append(Deliveries).Append("\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
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
            return Equals(input as WebhookProperties);
        }

        /// <summary>
        /// Returns true if WebhookProperties instances are equal
        /// </summary>
        /// <param name="input">Instance of WebhookProperties to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WebhookProperties input)
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
                    Active == input.Active ||
                    Active.Equals(input.Active)
                ) && 
                (
                    Title == input.Title ||
					Title.Equals(input.Title)
                ) && 
                (
                    Secret == input.Secret ||
					Secret.Equals(input.Secret)
                ) && 
                (
                    Triggers == input.Triggers ||
                    Triggers != null &&
                    input.Triggers != null &&
                    Triggers.SequenceEqual(input.Triggers)
                ) && 
                (
                    Responses == input.Responses ||
                    Responses != null &&
                    input.Responses != null &&
                    Responses.SequenceEqual(input.Responses)
                ) && 
                (
                    Deliveries == input.Deliveries ||
                    Deliveries != null &&
                    input.Deliveries != null &&
                    Deliveries.SequenceEqual(input.Deliveries)
                ) && 
                (
                    Url == input.Url ||
					Url.Equals(input.Url)
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
                hashCode = (hashCode * 59) + Active.GetHashCode();
				hashCode = (hashCode * 59) + Title.GetHashCode();
				hashCode = (hashCode * 59) + Secret.GetHashCode();
                if (Triggers != null)
                {
                    hashCode = (hashCode * 59) + Triggers.GetHashCode();
                }
                if (Responses != null)
                {
                    hashCode = (hashCode * 59) + Responses.GetHashCode();
                }
                if (Deliveries != null)
                {
                    hashCode = (hashCode * 59) + Deliveries.GetHashCode();
                }
				hashCode = (hashCode * 59) + Url.GetHashCode();
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
