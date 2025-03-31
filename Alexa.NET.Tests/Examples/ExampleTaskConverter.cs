using System.Text.Json;
using Alexa.NET.ConnectionTasks;
using Alexa.NET.Request.Type;

namespace Alexa.NET.Tests.Examples;

public class ExampleTaskConverter : IConnectionTaskConverter
{
    public bool CanConvert(JsonElement element)
    {
        return element.TryGetProperty("randomParameter", out _);
    }

    public IConnectionTask Convert(JsonElement element, JsonSerializerOptions options)
    {
        return new ExampleTask();
    }
}