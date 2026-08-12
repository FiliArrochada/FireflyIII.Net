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
    /// AutocompleteAccount
    /// </summary>
    [DataContract(Name = "AutocompleteAccount")]
    public partial class AutocompleteAccount : IEquatable<AutocompleteAccount>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteAccount" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AutocompleteAccount() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AutocompleteAccount" /> class.
        /// </summary>
        /// <param name="id">id (required).</param>
        /// <param name="name">Name of the account found by an auto-complete search. (required).</param>
        /// <param name="nameWithBalance">Asset accounts and liabilities have a second field with the given date&#39;s account balance. (required).</param>
        /// <param name="type">AccountProperties type of the account found by the auto-complete search. (required).</param>
        /// <param name="currencyId">ID for the currency used by this account. (required).</param>
        /// <param name="currencyName">CurrencyProperties name for the currency used by this account. (required).</param>
        /// <param name="currencyCode">CurrencyProperties code for the currency used by this account. (required).</param>
        /// <param name="currencySymbol">CurrencyProperties symbol for the currency used by this account. (required).</param>
        /// <param name="currencyDecimalPlaces">Number of decimal places for the currency used by this account. (required).</param>
        /// <param name="accountCurrencyId">ID for the currency used by this account. Even if &quot;convertToNative&quot; is on, the account currency ID is displayed here..</param>
        /// <param name="accountCurrencyName">Name for the currency used by this account. Even if &quot;convertToNative&quot; is on, the account currency name is displayed here..</param>
        /// <param name="accountCurrencyCode">Code for the currency used by this account. Even if &quot;convertToNative&quot; is on, the account currency code is displayed here..</param>
        /// <param name="accountCurrencySymbol">Code for the currency used by this account. Even if &quot;convertToNative&quot; is on, the account currency code is displayed here..</param>
        /// <param name="accountCurrencyDecimalPlaces">Number of decimal places for the currency used by this account. Even if &quot;convertToNative&quot; is on, the account currency code is displayed here..</param>
        /// <param name="active">Is the bill active or not?.</param>
        public AutocompleteAccount(string id = default(string), string name = default(string), string nameWithBalance = default(string), string type = default(string), string currencyId = default(string), string currencyName = default(string), string currencyCode = default(string), string currencySymbol = default(string), int currencyDecimalPlaces = default(int), string accountCurrencyId = default(string), string accountCurrencyName = default(string), string accountCurrencyCode = default(string), string accountCurrencySymbol = default(string), int accountCurrencyDecimalPlaces = default(int), bool active = default(bool))
        {
            // to ensure "id" is required (not null)
            if (id == null)
            {
                throw new ArgumentNullException("id is a required property for AutocompleteAccount and cannot be null");
            }
            Id = id;
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for AutocompleteAccount and cannot be null");
            }
            Name = name;
            // to ensure "nameWithBalance" is required (not null)
            if (nameWithBalance == null)
            {
                throw new ArgumentNullException("nameWithBalance is a required property for AutocompleteAccount and cannot be null");
            }
            NameWithBalance = nameWithBalance;
            // to ensure "type" is required (not null)
            if (type == null)
            {
                throw new ArgumentNullException("type is a required property for AutocompleteAccount and cannot be null");
            }
            Type = type;
            // to ensure "currencyId" is required (not null)
            if (currencyId == null)
            {
                throw new ArgumentNullException("currencyId is a required property for AutocompleteAccount and cannot be null");
            }
            CurrencyId = currencyId;
            // to ensure "currencyName" is required (not null)
            if (currencyName == null)
            {
                throw new ArgumentNullException("currencyName is a required property for AutocompleteAccount and cannot be null");
            }
            CurrencyName = currencyName;
            // to ensure "currencyCode" is required (not null)
            if (currencyCode == null)
            {
                throw new ArgumentNullException("currencyCode is a required property for AutocompleteAccount and cannot be null");
            }
            CurrencyCode = currencyCode;
            // to ensure "currencySymbol" is required (not null)
            if (currencySymbol == null)
            {
                throw new ArgumentNullException("currencySymbol is a required property for AutocompleteAccount and cannot be null");
            }
            CurrencySymbol = currencySymbol;
            CurrencyDecimalPlaces = currencyDecimalPlaces;
            AccountCurrencyId = accountCurrencyId;
            AccountCurrencyName = accountCurrencyName;
            AccountCurrencyCode = accountCurrencyCode;
            AccountCurrencySymbol = accountCurrencySymbol;
            AccountCurrencyDecimalPlaces = accountCurrencyDecimalPlaces;
            Active = active;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        /// <example>2</example>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the account found by an auto-complete search.
        /// </summary>
        /// <value>Name of the account found by an auto-complete search.</value>
        /// <example>Checking AccountProperties</example>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Asset accounts and liabilities have a second field with the given date&#39;s account balance.
        /// </summary>
        /// <value>Asset accounts and liabilities have a second field with the given date&#39;s account balance.</value>
        /// <example>Checking AccountProperties ($123.45)</example>
        [DataMember(Name = "name_with_balance", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("name_with_balance")]
        public string NameWithBalance { get; set; }

        /// <summary>
        /// Is the bill active or not?
        /// </summary>
        /// <value>Is the bill active or not?</value>
        /// <example>true</example>
        [DataMember(Name = "active", EmitDefaultValue = true)]
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        /// AccountProperties type of the account found by the auto-complete search.
        /// </summary>
        /// <value>AccountProperties type of the account found by the auto-complete search.</value>
        /// <example>Asset account</example>
        [DataMember(Name = "type", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// ID for the currency used by this account.
        /// </summary>
        /// <value>ID for the currency used by this account.</value>
        /// <example>12</example>
        [DataMember(Name = "currency_id", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("currency_id")]
        public string CurrencyId { get; set; }

        /// <summary>
        /// CurrencyProperties name for the currency used by this account.
        /// </summary>
        /// <value>CurrencyProperties name for the currency used by this account.</value>
        /// <example>Euro</example>
        [DataMember(Name = "currency_name", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("currency_name")]
        public string CurrencyName { get; set; }

        /// <summary>
        /// CurrencyProperties code for the currency used by this account.
        /// </summary>
        /// <value>CurrencyProperties code for the currency used by this account.</value>
        /// <example>EUR</example>
        [DataMember(Name = "currency_code", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// CurrencyProperties symbol for the currency used by this account.
        /// </summary>
        /// <value>CurrencyProperties symbol for the currency used by this account.</value>
        /// <example>$</example>
        [DataMember(Name = "currency_symbol", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("currency_symbol")]
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// Number of decimal places for the currency used by this account.
        /// </summary>
        /// <value>Number of decimal places for the currency used by this account.</value>
        /// <example>2</example>
        [DataMember(Name = "currency_decimal_places", IsRequired = true, EmitDefaultValue = true)]
        [JsonPropertyName("currency_decimal_places")]
        public int CurrencyDecimalPlaces { get; set; }

        /// <summary>
        /// ID for the currency used by this account. Even if &quot;convertToNative&quot; is on, the account currency ID is displayed here.
        /// </summary>
        /// <value>ID for the currency used by this account. Even if &quot;convertToNative&quot; is on, the account currency ID is displayed here.</value>
        /// <example>2</example>
        [DataMember(Name = "account_currency_id", EmitDefaultValue = true)]
        [JsonPropertyName("account_currency_id")]
        public string AccountCurrencyId { get; set; }

        /// <summary>
        /// Name for the currency used by this account. Even if &quot;convertToNative&quot; is on, the account currency name is displayed here.
        /// </summary>
        /// <value>Name for the currency used by this account. Even if &quot;convertToNative&quot; is on, the account currency name is displayed here.</value>
        /// <example>US Dollar</example>
        [DataMember(Name = "account_currency_name", EmitDefaultValue = true)]
        [JsonPropertyName("account_currency_name")]
        public string AccountCurrencyName { get; set; }

        /// <summary>
        /// Code for the currency used by this account. Even if &quot;convertToNative&quot; is on, the account currency code is displayed here.
        /// </summary>
        /// <value>Code for the currency used by this account. Even if &quot;convertToNative&quot; is on, the account currency code is displayed here.</value>
        /// <example>USD</example>
        [DataMember(Name = "account_currency_code", EmitDefaultValue = true)]
        [JsonPropertyName("account_currency_code")]
        public string AccountCurrencyCode { get; set; }

        /// <summary>
        /// Code for the currency used by this account. Even if &quot;convertToNative&quot; is on, the account currency code is displayed here.
        /// </summary>
        /// <value>Code for the currency used by this account. Even if &quot;convertToNative&quot; is on, the account currency code is displayed here.</value>
        /// <example>$</example>
        [DataMember(Name = "account_currency_symbol", EmitDefaultValue = true)]
        [JsonPropertyName("account_currency_symbol")]
        public string AccountCurrencySymbol { get; set; }

        /// <summary>
        /// Number of decimal places for the currency used by this account. Even if &quot;convertToNative&quot; is on, the account currency code is displayed here.
        /// </summary>
        /// <value>Number of decimal places for the currency used by this account. Even if &quot;convertToNative&quot; is on, the account currency code is displayed here.</value>
        /// <example>2</example>
        [DataMember(Name = "account_currency_decimal_places", EmitDefaultValue = true)]
        [JsonPropertyName("account_currency_decimal_places")]
        public int AccountCurrencyDecimalPlaces { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class AutocompleteAccount {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  NameWithBalance: ").Append(NameWithBalance).Append("\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  CurrencyId: ").Append(CurrencyId).Append("\n");
            sb.Append("  CurrencyName: ").Append(CurrencyName).Append("\n");
            sb.Append("  CurrencyCode: ").Append(CurrencyCode).Append("\n");
            sb.Append("  CurrencySymbol: ").Append(CurrencySymbol).Append("\n");
            sb.Append("  CurrencyDecimalPlaces: ").Append(CurrencyDecimalPlaces).Append("\n");
            sb.Append("  AccountCurrencyId: ").Append(AccountCurrencyId).Append("\n");
            sb.Append("  AccountCurrencyName: ").Append(AccountCurrencyName).Append("\n");
            sb.Append("  AccountCurrencyCode: ").Append(AccountCurrencyCode).Append("\n");
            sb.Append("  AccountCurrencySymbol: ").Append(AccountCurrencySymbol).Append("\n");
            sb.Append("  AccountCurrencyDecimalPlaces: ").Append(AccountCurrencyDecimalPlaces).Append("\n");
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
            return Equals(input as AutocompleteAccount);
        }

        /// <summary>
        /// Returns true if AutocompleteAccount instances are equal
        /// </summary>
        /// <param name="input">Instance of AutocompleteAccount to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AutocompleteAccount input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    Id == input.Id ||
					Id.Equals(input.Id)
                ) && 
                (
                    Name == input.Name ||
					Name.Equals(input.Name)
                ) && 
                (
                    NameWithBalance == input.NameWithBalance ||
					NameWithBalance.Equals(input.NameWithBalance)
                ) &&
                (
                    Active == input.Active ||
                    Active.Equals(input.Active)
                ) &&
                (
                    Type == input.Type ||
					Type.Equals(input.Type)
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
                    AccountCurrencyId == input.AccountCurrencyId ||
                    (AccountCurrencyId != null &&
                    AccountCurrencyId.Equals(input.AccountCurrencyId))
                ) &&
                (
                    AccountCurrencyName == input.AccountCurrencyName ||
                    (AccountCurrencyName != null &&
                    AccountCurrencyName.Equals(input.AccountCurrencyName))
                ) &&
                (
                    AccountCurrencyCode == input.AccountCurrencyCode ||
                    (AccountCurrencyCode != null &&
                    AccountCurrencyCode.Equals(input.AccountCurrencyCode))
                ) &&
                (
                    AccountCurrencySymbol == input.AccountCurrencySymbol ||
                    (AccountCurrencySymbol != null &&
                    AccountCurrencySymbol.Equals(input.AccountCurrencySymbol))
                ) &&
                (
                    AccountCurrencyDecimalPlaces == input.AccountCurrencyDecimalPlaces ||
                    AccountCurrencyDecimalPlaces.Equals(input.AccountCurrencyDecimalPlaces)
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
				hashCode = (hashCode * 59) + Id.GetHashCode();
				hashCode = (hashCode * 59) + Name.GetHashCode();
				hashCode = (hashCode * 59) + NameWithBalance.GetHashCode();
                hashCode = (hashCode * 59) + Active.GetHashCode();
				hashCode = (hashCode * 59) + Type.GetHashCode();
				hashCode = (hashCode * 59) + CurrencyId.GetHashCode();
				hashCode = (hashCode * 59) + CurrencyName.GetHashCode();
				hashCode = (hashCode * 59) + CurrencyCode.GetHashCode();
				hashCode = (hashCode * 59) + CurrencySymbol.GetHashCode();
                hashCode = (hashCode * 59) + CurrencyDecimalPlaces.GetHashCode();
                if (AccountCurrencyId != null)
                {
                    hashCode = (hashCode * 59) + AccountCurrencyId.GetHashCode();
                }
                if (AccountCurrencyName != null)
                {
                    hashCode = (hashCode * 59) + AccountCurrencyName.GetHashCode();
                }
                if (AccountCurrencyCode != null)
                {
                    hashCode = (hashCode * 59) + AccountCurrencyCode.GetHashCode();
                }
                if (AccountCurrencySymbol != null)
                {
                    hashCode = (hashCode * 59) + AccountCurrencySymbol.GetHashCode();
                }
                hashCode = (hashCode * 59) + AccountCurrencyDecimalPlaces.GetHashCode();
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
