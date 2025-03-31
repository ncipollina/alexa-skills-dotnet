
using System.Text.Json.Serialization;

namespace Alexa.NET.Response.Directive;

public class SlotTypeValue
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public SlotTypeValueName Name { get; set; }
}