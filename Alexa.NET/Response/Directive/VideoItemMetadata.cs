using System.Text.Json.Serialization;

namespace Alexa.NET.Response.Directive;

public class VideoItemMetadata
{
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Title { get; set; }

    [JsonPropertyName("subtitle")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Subtitle { get; set; }
}