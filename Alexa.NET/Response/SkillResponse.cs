﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Alexa.NET.Response;

public class SkillResponse
{
    [JsonRequired]
    [JsonPropertyName("version")]
    public string Version { get; set; }

    [JsonPropertyName("sessionAttributes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object>? SessionAttributes { get; set; }

    [JsonRequired]
    [JsonPropertyName("response")]
    public ResponseBody Response { get; set; }
}