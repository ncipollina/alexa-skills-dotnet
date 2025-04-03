using System.Text.Json.Serialization;

namespace Alexa.NET.Request.Type;

public class DisplayElementSelectedRequest:Request
{
    [JsonPropertyName("token")]
    public string Token { get; set; }
}