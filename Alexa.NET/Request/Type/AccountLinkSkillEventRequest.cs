using System.Text.Json.Serialization;

namespace Alexa.NET.Request.Type;

public class AccountLinkSkillEventRequest : SkillEventRequest
{
    [JsonPropertyName("body")] public AccountLinkSkillEventDetail Body { get; set; }
}