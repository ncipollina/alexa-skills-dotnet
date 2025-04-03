using System.Text.Json.Serialization;
using Alexa.NET.Response.Converters;

namespace Alexa.NET.Request.Type;

public class SessionEndedRequest : Request
{
    [JsonPropertyName("reason")]
    [JsonConverter(typeof(JsonStringEnumConverterWithEnumMemberAttrSupport<Reason>))]
    public Reason Reason { get; set; }

    [JsonPropertyName("error")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Error? Error { get; set; }
}