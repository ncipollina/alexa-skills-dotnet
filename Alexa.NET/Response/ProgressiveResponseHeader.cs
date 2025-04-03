using System.Text.Json.Serialization;

namespace Alexa.NET.Response;

public class ProgressiveResponseHeader
{
    public ProgressiveResponseHeader(string requestId)
    {
        RequestId = requestId;
    }

    [JsonPropertyName("requestId")]
    public string RequestId { get; }
}