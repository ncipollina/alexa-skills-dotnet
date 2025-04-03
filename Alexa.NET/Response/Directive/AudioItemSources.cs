using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Alexa.NET.Response.Directive;

public class AudioItemSources
{
	[JsonPropertyName("sources")]
	public List<AudioItemSource> Sources { get; set; } = [];
}