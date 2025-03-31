using System.Text.Json.Serialization;

namespace Alexa.NET.Request;

public class ResolutionStatus
{
    [JsonPropertyName("code")]
    public string Code { get; set; }
}