/*
 * Firefly III API
 *
 * System.Text.Json converter for enums, preserving the behaviour of the previous
 * Newtonsoft.Json StringEnumConverter: enum values are (de)serialized using their
 * [EnumMember(Value = "...")] value when present, otherwise the member name.
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FireflyIIINet.Client
{
    /// <summary>
    /// A <see cref="JsonConverterFactory"/> that serializes enums as strings using their
    /// <see cref="EnumMemberAttribute"/> value when available. This mirrors the behaviour of
    /// Newtonsoft.Json's <c>StringEnumConverter</c> combined with <c>EnumMemberAttribute</c>,
    /// which System.Text.Json's built-in <c>JsonStringEnumConverter</c> does not honour on
    /// all target frameworks.
    /// </summary>
    public sealed class StringEnumMemberConverter : JsonConverterFactory
    {
        // Only the non-nullable enum is handled directly; System.Text.Json automatically
        // wraps this converter for Nullable<TEnum> properties.

        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsEnum;
        }

        /// <inheritdoc />
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            var converterType = typeof(EnumMemberConverter<>).MakeGenericType(typeToConvert);
            return (JsonConverter)Activator.CreateInstance(converterType);
        }

        private sealed class EnumMemberConverter<T> : JsonConverter<T> where T : struct, Enum
        {
            private readonly Dictionary<string, T> _read = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
            private readonly Dictionary<T, string> _write = new Dictionary<T, string>();

            public EnumMemberConverter()
            {
                foreach (var name in Enum.GetNames(typeof(T)))
                {
                    var value = (T)Enum.Parse(typeof(T), name);
                    var field = typeof(T).GetField(name);
                    var attr = field?.GetCustomAttribute<EnumMemberAttribute>();
                    var serialized = attr?.Value ?? name;

                    _read[serialized] = value;
                    if (!_read.ContainsKey(name)) _read[name] = value;
                    if (!_write.ContainsKey(value)) _write[value] = serialized;
                }
            }

            public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.String)
                {
                    var s = reader.GetString();
                    if (s != null && _read.TryGetValue(s, out var value))
                    {
                        return value;
                    }

                    if (Enum.TryParse<T>(s, true, out var parsed))
                    {
                        return parsed;
                    }

                    throw new JsonException($"Unable to convert \"{s}\" to enum {typeof(T)}.");
                }

                if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out var number))
                {
                    return (T)Enum.ToObject(typeof(T), number);
                }

                throw new JsonException($"Unexpected token {reader.TokenType} when parsing enum {typeof(T)}.");
            }

            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            {
                if (_write.TryGetValue(value, out var s))
                {
                    writer.WriteStringValue(s);
                }
                else
                {
                    writer.WriteStringValue(value.ToString());
                }
            }
        }
    }
}
