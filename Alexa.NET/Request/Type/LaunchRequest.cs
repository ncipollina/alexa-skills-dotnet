using System.Text.Json.Serialization;

namespace Alexa.NET.Request.Type;

public class LaunchRequest : Request
{
    [JsonPropertyName("task")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public LaunchRequestTask Task { get; set; }
}