using System.Text.Json.Serialization;
using Alexa.NET.Request;

namespace Alexa.NET.Response.Directive;

public class DialogElicitSlot : IDirective
{
    public const string DirectiveType = "Dialog.ElicitSlot";

    [JsonPropertyName("type")]
    public string Type => DirectiveType;

    [JsonPropertyName("slotToElicit"), JsonRequired]
    public string SlotName { get; set; }

    [JsonPropertyName("updatedIntent")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Intent UpdatedIntent { get; set; }

    public DialogElicitSlot(string slotName)
    {
        SlotName = slotName;
    }

    internal DialogElicitSlot()
    {
    }
}