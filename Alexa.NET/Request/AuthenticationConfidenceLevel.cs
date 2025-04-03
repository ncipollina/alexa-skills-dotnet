using System.Text.Json.Serialization;

namespace Alexa.NET.Request;

public class AuthenticationConfidenceLevel
{
    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("customPolicy")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AuthenticationConfidenceLevelCustomPolicy Custom { get; set; }
}