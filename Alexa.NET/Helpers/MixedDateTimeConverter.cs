using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Alexa.NET.Helpers;

public class MixedDateTimeConverter : JsonConverter<DateTime>
{
    private static readonly DateTime UnixEpoch = 
        new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
                var stringValue = reader.GetString();
                if (DateTime.TryParse(stringValue, out var parsed))
                {
                    return parsed;
                }
                throw new JsonException($"Invalid date string: {stringValue}");

            case JsonTokenType.Number:
                if (reader.TryGetInt64(out var epoch))
                {
                    return UnixEpoch.AddMilliseconds(epoch);
                }
                throw new JsonException("Invalid epoch format");

            default:
                throw new JsonException($"Unexpected token parsing DateTime: {reader.TokenType}");
        }
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        // Write as ISO 8601 string
        writer.WriteStringValue(value.ToString("O")); // O = round-trip format
    }
}