/*
 * Firefly III API
 *
 * Reads and writes the "entries" of a chart data set.
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using FireflyIIINet.Model;

namespace FireflyIIINet.Client
{
    /// <summary>
    /// Converts a chart data set's <c>entries</c> between the server's shape and a list of points.
    /// </summary>
    /// <remarks>
    /// The specification declares <c>entries</c> as <c>type: object</c> with <c>items</c>, which
    /// no generator reads the same way; the server sends an object keyed by the point's label,
    /// <c>{"2026-10-01T00:00:00+01:00": "123.45", "2026-10-02T00:00:00+01:00": 120}</c>, in
    /// chart order. The value may be a JSON number or a numeric string, and an empty set comes
    /// as <c>[]</c> (PHP's empty array). An array of <c>{"key", "value"}</c> objects is read too.
    /// The list keeps the server's order; writing produces the object shape again.
    /// </remarks>
    /// <typeparam name="TPoint">The point model.</typeparam>
    public abstract class ChartEntriesConverter<TPoint> : JsonConverter<List<TPoint>>
    {
        /// <summary>Builds a point from its label and value.</summary>
        protected abstract TPoint Create(string key, decimal? value);

        /// <summary>The point's label.</summary>
        protected abstract string KeyOf(TPoint point);

        /// <summary>The point's value.</summary>
        protected abstract decimal? ValueOf(TPoint point);

        /// <inheritdoc />
        public override List<TPoint> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var points = new List<TPoint>();
            switch (reader.TokenType)
            {
                case JsonTokenType.Null:
                    return null;

                case JsonTokenType.StartObject:
                    while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
                    {
                        var key = reader.GetString();
                        reader.Read();
                        points.Add(Create(key, ReadValue(ref reader)));
                    }

                    return points;

                case JsonTokenType.StartArray:
                    while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                    {
                        if (reader.TokenType != JsonTokenType.StartObject)
                        {
                            throw new JsonException($"A chart entry must be an object, not {reader.TokenType}.");
                        }

                        string key = null;
                        decimal? value = null;
                        while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
                        {
                            var name = reader.GetString();
                            reader.Read();
                            if (string.Equals(name, "key", StringComparison.OrdinalIgnoreCase))
                            {
                                key = reader.TokenType == JsonTokenType.Null ? null : reader.GetString();
                            }
                            else if (string.Equals(name, "value", StringComparison.OrdinalIgnoreCase))
                            {
                                value = ReadValue(ref reader);
                            }
                            else
                            {
                                reader.Skip();
                            }
                        }

                        points.Add(Create(key, value));
                    }

                    return points;

                default:
                    throw new JsonException($"Chart entries must be an object or an array, not {reader.TokenType}.");
            }
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, List<TPoint> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            foreach (var point in value)
            {
                writer.WritePropertyName(KeyOf(point) ?? string.Empty);
                var number = ValueOf(point);
                if (number.HasValue)
                {
                    writer.WriteNumberValue(number.Value);
                }
                else
                {
                    writer.WriteNullValue();
                }
            }

            writer.WriteEndObject();
        }

        private static decimal? ReadValue(ref Utf8JsonReader reader)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.Number:
                    return reader.TryGetDecimal(out var number) ? number : (decimal)reader.GetDouble();
                case JsonTokenType.String:
                    return decimal.TryParse(reader.GetString(), NumberStyles.Float, CultureInfo.InvariantCulture, out var parsed) ? parsed : (decimal?)null;
                case JsonTokenType.Null:
                    return null;
                default:
                    throw new JsonException($"A chart value must be a number or a numeric string, not {reader.TokenType}.");
            }
        }
    }

    /// <summary>The <see cref="ChartEntriesConverter{TPoint}"/> for v1 charts (<see cref="ChartDataSet"/>).</summary>
    public sealed class ChartDataPointListConverter : ChartEntriesConverter<ChartDataPoint>
    {
        /// <inheritdoc />
        protected override ChartDataPoint Create(string key, decimal? value) => new ChartDataPoint(key, value);

        /// <inheritdoc />
        protected override string KeyOf(ChartDataPoint point) => point.Key;

        /// <inheritdoc />
        protected override decimal? ValueOf(ChartDataPoint point) => point.Value;
    }

    /// <summary>The <see cref="ChartEntriesConverter{TPoint}"/> for v2 charts (<see cref="ChartDataSetV2"/>).</summary>
    public sealed class ChartDataPointV2ListConverter : ChartEntriesConverter<ChartDataPointV2>
    {
        /// <inheritdoc />
        protected override ChartDataPointV2 Create(string key, decimal? value) => new ChartDataPointV2(key, value);

        /// <inheritdoc />
        protected override string KeyOf(ChartDataPointV2 point) => point.Key;

        /// <inheritdoc />
        protected override decimal? ValueOf(ChartDataPointV2 point) => point.Value;
    }
}
