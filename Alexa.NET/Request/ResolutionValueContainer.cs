using System.Text.Json.Serialization;

namespace Alexa.NET.Request;

public class ResolutionValueContainer
{
    [JsonPropertyName("value")]
    public ResolutionValue Value { get; set; }
}