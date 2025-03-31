﻿using System.Text.Json.Serialization;

namespace Alexa.NET.Request;

public class ResolutionAuthority
{
    [JsonPropertyName("authority")]
    public string Name { get; set; }

    [JsonPropertyName("status")]
    public ResolutionStatus Status { get; set; }

    [JsonPropertyName("values"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ResolutionValueContainer[]? Values { get; set; }
}