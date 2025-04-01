using System.Text.Json.Serialization;
using Alexa.NET.Response.Converters;
using Alexa.NET.Response.Directive;

namespace Alexa.NET.Response;

public class PlainTextOutputSpeech : IOutputSpeech
{
    public const string SpeechType = "PlainText";

    public PlainTextOutputSpeech()
    {

    }

    public PlainTextOutputSpeech(string text)
    {
        Text = text;
    }

    [JsonPropertyName("type")]
    public string Type => SpeechType;

    [JsonRequired]
    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("playBehavior")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(JsonStringEnumConverterWithEnumMemberAttrSupport<PlayBehavior>))]
    public PlayBehavior? PlayBehavior { get; set; }
}