/*
 * Firefly III API
 *
 * System.Text.Json converter that lets string properties read JSON numbers.
 */

using System;
using System.Buffers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FireflyIIINet.Client
{
    /// <summary>
    /// Reads a JSON number into a <see cref="string"/> property as its literal text. The spec
    /// types ids as strings and the server mostly agrees, but not everywhere: an available
    /// budget's <c>spent_in_budgets[].currency_id</c> comes back as <c>1</c>. Strings are written
    /// unchanged.
    /// </summary>
    public sealed class NumberAsStringConverter : JsonConverter<string>
    {
        /// <inheritdoc />
        public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                return Encoding.UTF8.GetString(reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan.ToArray());
            }
            return reader.GetString();
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}
