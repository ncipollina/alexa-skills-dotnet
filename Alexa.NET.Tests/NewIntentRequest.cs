using System.Text.Json.Serialization;

namespace Alexa.NET.Tests;

public class NewIntentRequest : Request.Type.Request
{
    [JsonPropertyName("testProperty")]
    public bool TestProperty { get; set; }
}