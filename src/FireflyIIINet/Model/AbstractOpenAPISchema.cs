/*
 * Firefly III API v6.1.22
 *
 * This is the documentation of the Firefly III API. You can find accompanying documentation on the website of Firefly III itself (see below). Please report any bugs or issues. You may use the \"Authorize\" button to try the API below. This file was last generated on 2024-11-09T05:39:26+00:00
 *
 * The version of the OpenAPI document: 6.1.22
 * Contact: james@firefly-iii.org
 */


using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using FireflyIIINet.Client;

namespace FireflyIIINet.Model
{
    /// <summary>
    ///  Abstract base class for oneOf, anyOf schemas in the OpenAPI specification
    /// </summary>
    public abstract partial class AbstractOpenAPISchema
    {
        /// <summary>
        ///  Custom JSON serializer. Unknown members are disallowed so that oneOf/anyOf
        ///  candidate types only match when the payload maps exactly, mirroring the previous
        ///  Newtonsoft <c>MissingMemberHandling.Error</c> behaviour.
        /// </summary>
        public static readonly JsonSerializerOptions SerializerSettings = BuildStrictOptions();

        /// <summary>
        ///  Custom JSON serializer for objects with additional properties (unknown members ignored).
        /// </summary>
        public static readonly JsonSerializerOptions AdditionalPropertiesSerializerSettings = BuildLenientOptions();

        private static JsonSerializerOptions BuildStrictOptions()
        {
            // No AllowReadingFromString: keeps oneOf/anyOf candidates mutually exclusive by JSON
            // shape (e.g. a quoted number must not also match an `int` candidate).
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
            };
            options.Converters.Add(new StringEnumMemberConverter());
            return options;
        }

        private static JsonSerializerOptions BuildLenientOptions()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString
            };
            options.Converters.Add(new StringEnumMemberConverter());
            return options;
        }

        /// <summary>
        /// Gets or Sets the actual instance
        /// </summary>
        public abstract Object ActualInstance { get; set; }

        /// <summary>
        /// Gets or Sets IsNullable to indicate whether the instance is nullable
        /// </summary>
        public bool IsNullable { get; protected set; }

        /// <summary>
        /// Gets or Sets the schema type, which can be either `oneOf` or `anyOf`
        /// </summary>
        public string SchemaType { get; protected set; }

        /// <summary>
        /// Converts the instance into JSON string.
        /// </summary>
        public abstract string ToJson();
    }
}
