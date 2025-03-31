using Newtonsoft.Json;

namespace Alexa.NET.Request.Type;

public class ErrorCause
{
    [JsonProperty("requestId")]
    public string requestId { get; set; }
}