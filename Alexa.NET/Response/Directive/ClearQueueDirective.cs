using System.Text.Json.Serialization;
using Alexa.NET.Response.Converters;

namespace Alexa.NET.Response.Directive;

public class ClearQueueDirective : IDirective
{
    public const string DirectiveType = "AudioPlayer.ClearQueue";

    [JsonPropertyName("type")]
    public string Type => DirectiveType;

    [JsonPropertyName("clearBehavior")]
    [JsonRequired]
    [JsonConverter(typeof(JsonStringEnumConverterWithEnumMemberAttrSupport<ClearBehavior>))]
    public ClearBehavior ClearBehavior { get; set; }
}