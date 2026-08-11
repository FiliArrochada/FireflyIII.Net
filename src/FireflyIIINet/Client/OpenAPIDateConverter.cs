/*
 * Firefly III API v2.0.8
 *
 * System.Text.Json converter for 'date' openapi formats (full-date, RFC3339).
 */

using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FireflyIIINet.Client
{
    /// <summary>
    /// Formatter for 'date' openapi formats as defined by full-date - RFC3339
    /// see https://github.com/OAI/OpenAPI-Specification/blob/master/versions/3.0.0.md#data-types
    /// </summary>
    public class OpenAPIDateConverter : JsonConverter<DateTime>
    {
        // full-date   = date-fullyear "-" date-month "-" date-mday
        private const string DateFormat = "yyyy-MM-dd";

        /// <summary>
        /// Reads a date-only value.
        /// </summary>
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateTime.ParseExact(value, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None);
        }

        /// <summary>
        /// Writes a date-only value.
        /// </summary>
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(DateFormat, CultureInfo.InvariantCulture));
        }
    }
}
