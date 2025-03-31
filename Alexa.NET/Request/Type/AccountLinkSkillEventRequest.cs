using Newtonsoft.Json;

namespace Alexa.NET.Request.Type;

public class AccountLinkSkillEventRequest:SkillEventRequest
{
    [JsonProperty("body")]
    public AccountLinkSkillEventDetail Body { get; set; }
}