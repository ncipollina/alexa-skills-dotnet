using System.Text.Json.Serialization;

namespace Alexa.NET.Request.Type;

public class SystemExceptionRequest : Request
{
    [JsonPropertyName("error")]
    public Error Error { get; set; }
    [JsonPropertyName("cause")]
    public ErrorCause ErrorCause { get; set; }
}