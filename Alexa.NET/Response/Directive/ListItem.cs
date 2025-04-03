using System.Text.Json.Serialization;
using Alexa.NET.Response.Directive.Templates;

namespace Alexa.NET.Response.Directive;

public class ListItem
{
    [JsonPropertyName("token")]
    public string Token { get; set; }
        
    [JsonPropertyName("image")]
    public TemplateImage Image { get; set; }
        
    [JsonPropertyName("textContent")]
    public TemplateContent Content { get; set; }
}