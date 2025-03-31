using System.Text.Json.Serialization;

namespace Alexa.NET.Response.Directive;

public class AudioItemStream
{
    [JsonRequired]
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonRequired]
    [JsonPropertyName("token")]
    public string Token { get; set; }
        
    [JsonPropertyName("expectedPreviousToken")]
    public string ExpectedPreviousToken { get; set; }

    [JsonRequired]
    [JsonPropertyName("offsetInMilliseconds")]
    public int OffsetInMilliseconds { get; set; }
}