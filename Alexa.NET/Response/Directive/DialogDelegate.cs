using System.Text.Json.Serialization;
using Alexa.NET.Request;

namespace Alexa.NET.Response.Directive;

public class DialogDelegate:IDirective
{
    public const string DirectiveType = "Dialog.Delegate";

    [JsonPropertyName("type")]
    public string Type => DirectiveType;

    [JsonPropertyName("updatedIntent")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Intent UpdatedIntent { get; set; }
}