using System;
using System.Text.Json;
using Alexa.NET.ConnectionTasks;
using Alexa.NET.Request.Type;

namespace Alexa.NET.Tests.Examples;

public class ExampleTaskResolver : IConnectionTaskResolver
{
    public bool CanResolve(JsonElement element)
    {
        return element.TryGetProperty("randomParameter", out _);
    }

    public Type? Resolve(JsonElement element)
    {
        return  typeof(ExampleTask);
    }
}