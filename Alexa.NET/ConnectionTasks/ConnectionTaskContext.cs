using System.Text.Json.Serialization;

namespace Alexa.NET.ConnectionTasks;

public class ConnectionTaskContext
{
    [JsonPropertyName("providerId")]
    public string ProviderId { get; set; }
}