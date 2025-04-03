﻿using System.Text.Json.Serialization;

namespace Alexa.NET.Response.Directive;

public class AudioItem
{
    [JsonRequired]
    [JsonPropertyName("stream")]
    public AudioItemStream Stream { get; set; }

    [JsonPropertyName("metadata")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public AudioItemMetadata Metadata { get; set; }
}