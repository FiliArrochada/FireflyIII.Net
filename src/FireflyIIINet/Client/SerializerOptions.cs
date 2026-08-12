/*
 * Firefly III API v6.4.4
 *
 * Shared System.Text.Json serialization options used across the client.
 */

using System.Text.Json;
using System.Text.Json.Serialization;

namespace FireflyIIINet.Client
{
    /// <summary>
    /// Provides the shared <see cref="JsonSerializerOptions"/> instances used to (de)serialize
    /// models with System.Text.Json. Property names are taken from each model's explicit
    /// <c>[JsonPropertyName]</c> attributes; enums are handled by <see cref="StringEnumMemberConverter"/>.
    /// </summary>
    public static class SerializerOptions
    {
        private static JsonSerializerOptions Build(bool indented)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = indented,
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.Never,
                NumberHandling = JsonNumberHandling.AllowReadingFromString
            };
            options.Converters.Add(new StringEnumMemberConverter());
            return options;
        }

        /// <summary>
        /// Default options (compact output).
        /// </summary>
        public static readonly JsonSerializerOptions Default = Build(false);

        /// <summary>
        /// Options producing indented (pretty-printed) output, used by model <c>ToJson</c> methods.
        /// </summary>
        public static readonly JsonSerializerOptions Indented = Build(true);
    }
}
