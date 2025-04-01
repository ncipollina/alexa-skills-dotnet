using System.Text.Json.Serialization;

namespace Alexa.NET.Response;

public class LinkAccountCard : ICard
{
    public const string CardType = "LinkAccount";

    [JsonPropertyName("type")]
    public string Type => CardType;
}