
using System.Text.Json.Serialization;

namespace Alexa.NET.Response;

public class StandardCard : ICard
{
    [JsonPropertyName("type")]
    public string Type => "Standard";

    [JsonRequired]
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonRequired]
    [JsonPropertyName("text")]
    public string Content { get; set; }

    [JsonPropertyName("image")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CardImage Image { get; set; }
}