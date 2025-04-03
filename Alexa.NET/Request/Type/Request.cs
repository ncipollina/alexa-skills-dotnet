using System;
using System.Text.Json.Serialization;
using Alexa.NET.Helpers;

namespace Alexa.NET.Request.Type;

[JsonConverter(typeof(RequestConverter))]
public abstract class Request
{
    [JsonPropertyName("type")]
    [JsonRequired]
    public string Type { get; set; }

    [JsonPropertyName("requestId")]
    public string RequestId { get; set; }

    [JsonPropertyName("locale")]
    public string Locale { get; set; }

    [JsonPropertyName("timestamp"),JsonConverter(typeof(MixedDateTimeConverter))]
    public DateTime Timestamp { get; set; }
}