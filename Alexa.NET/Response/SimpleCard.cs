using System.Text.Json.Serialization;

namespace Alexa.NET.Response;

public class SimpleCard : ICard
{
    public const string CardType = "Simple";

    [JsonPropertyName("type")]
    public string Type => CardType;

    [JsonPropertyName("title")]
    [JsonRequired]
    public string Title { get; set; }

    [JsonRequired]
    [JsonPropertyName("content")]
    public string Content { get; set; }
}