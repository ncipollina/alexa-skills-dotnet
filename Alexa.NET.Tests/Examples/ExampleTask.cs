using System.Text.Json.Serialization;
using Alexa.NET.ConnectionTasks;

namespace Alexa.NET.Tests.Examples;

public class ExampleTask : IConnectionTask
{
    public string ConnectionUri { get; set; }
    [JsonPropertyName("randomParameter")]
    public string RandomParameter { get; set; }
}