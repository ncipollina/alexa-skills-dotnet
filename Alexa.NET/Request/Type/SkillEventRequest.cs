using System;
using System.Text.Json.Serialization;
using Alexa.NET.Helpers;

namespace Alexa.NET.Request.Type;

public class SkillEventRequest:Request
{
    [JsonPropertyName("eventCreationTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(MixedDateTimeConverter))]
    public DateTime? EventCreationTime { get; set; }

    [JsonPropertyName("eventPublishingTime")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(MixedDateTimeConverter))]
    public DateTime? EventPublishingTime { get; set; }
}