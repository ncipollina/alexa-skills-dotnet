using System.Text.Json.Serialization;
using Alexa.NET.Response.Converters;

namespace Alexa.NET.Response.Directive;

public class AudioPlayerPlayDirective : IDirective
{
    public const string DirectiveType = "AudioPlayer.Play";

    [JsonPropertyName("playBehavior")]
    [JsonRequired]
    [JsonConverter(typeof(JsonStringEnumConverterWithEnumMemberAttrSupport<PlayBehavior>))]
    public PlayBehavior PlayBehavior { get; set; }

    [JsonPropertyName("audioItem")]
    [JsonRequired]
    public AudioItem AudioItem { get; set; }

    [JsonPropertyName("type")]
    public string Type => DirectiveType;
}