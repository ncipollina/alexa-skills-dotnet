using System.Text.Json.Serialization;
using Alexa.NET.Response.Converters;
using Alexa.NET.Response.Directive;

namespace Alexa.NET.Response;

public class SsmlOutputSpeech : IOutputSpeech
{
    public const string SpeechType = "SSML";

    public SsmlOutputSpeech()
    {

    }

    public SsmlOutputSpeech(string ssml)
    {
        Ssml = ssml;
    }

    [JsonPropertyName("type")]
    public string Type => SpeechType;

    [JsonRequired]
    [JsonPropertyName("ssml")]
    public string Ssml { get; set; }

    [JsonPropertyName("playBehavior")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(JsonStringEnumConverterWithEnumMemberAttrSupport<PlayBehavior>))]
    public PlayBehavior? PlayBehavior { get; set; }
}