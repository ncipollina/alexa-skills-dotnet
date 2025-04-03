using System.Text.Json.Serialization;

namespace Alexa.NET.Request;

public class Scope
{
    [JsonPropertyName("status")]
    public string Status { get; set; }
}