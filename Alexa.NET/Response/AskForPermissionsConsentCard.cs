using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Alexa.NET.Response;

public class AskForPermissionsConsentCard : ICard
{

    [JsonPropertyName("type")]
    public string Type => "AskForPermissionsConsent";

    [JsonPropertyName("permissions")]
    [JsonRequired]
    public List<string> Permissions { get; set; } = [];
}