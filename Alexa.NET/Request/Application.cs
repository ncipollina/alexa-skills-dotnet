using System.Text.Json.Serialization;

namespace Alexa.NET.Request;

public class Application
{
    [JsonPropertyName("applicationId")]
    public string ApplicationId { get; set; }
}