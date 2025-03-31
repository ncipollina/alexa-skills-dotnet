using System.Text.Json.Serialization;

namespace Alexa.NET.Response.Directive;

public class AudioItemSource
{
	public AudioItemSource()
	{
	}

	public AudioItemSource(string url)
	{
		Url = url;
	}

	[JsonPropertyName("url"), JsonRequired]
	public string Url { get; set; }
}