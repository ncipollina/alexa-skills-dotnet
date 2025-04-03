using System.Text.Json.Serialization;

namespace Alexa.NET.Request.Type;

public class PermissionSkillEventRequest : SkillEventRequest
{
    [JsonPropertyName("body")] public SkillEventPermissions Body { get; set; }
}