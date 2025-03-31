using System.Text.Json.Serialization;

namespace Alexa.NET.Response;

public class SimpleCard : ICard
{
    [JsonPropertyName("type")]
    public string Type => "Simple";

    [JsonPropertyName("title")]
    [JsonRequired]
    public string Title { get; set; }

    [JsonRequired]
    [JsonPropertyName("content")]
    public string Content { get; set; }
}