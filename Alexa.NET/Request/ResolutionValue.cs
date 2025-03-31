using System.Text.Json.Serialization;

namespace Alexa.NET.Request;

public class ResolutionValue
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }
}