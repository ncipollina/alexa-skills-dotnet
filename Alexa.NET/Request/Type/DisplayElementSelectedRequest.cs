using Newtonsoft.Json;

namespace Alexa.NET.Request.Type;

public class DisplayElementSelectedRequest:Request
{
    [JsonProperty("token")]
    public string Token { get; set; }
}