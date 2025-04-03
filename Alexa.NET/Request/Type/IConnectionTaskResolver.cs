using System.Text.Json;

namespace Alexa.NET.Request.Type;

public interface IConnectionTaskResolver
{
    bool CanResolve(JsonElement element);
    System.Type? Resolve(JsonElement element);
}