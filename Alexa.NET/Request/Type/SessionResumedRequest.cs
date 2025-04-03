using System.Text.Json.Serialization;

namespace Alexa.NET.Request.Type;

public class SessionResumedRequest:Request
{
    [JsonPropertyName("originIpAddress")]
    public string OriginIpAddress { get; set; }

    [JsonPropertyName("cause")]
    public SessionResumedRequestCause Cause { get; set; }
}