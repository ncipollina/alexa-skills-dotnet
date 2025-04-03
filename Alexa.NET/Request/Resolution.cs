using System.Text.Json.Serialization;

namespace Alexa.NET.Request;

public class Resolution
{
    [JsonPropertyName("resolutionsPerAuthority")]
    public ResolutionAuthority[] Authorities { get; set; }
}