using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Alexa.NET.Response;

public class AskForPermissionsConsentCard : ICard
{
    public const string CardType = "AskForPermissionsConsent";

    [JsonPropertyName("type")]
    public string Type => CardType;

    [JsonPropertyName("permissions")]
    [JsonRequired]
    public List<string> Permissions { get; set; } = [];
}