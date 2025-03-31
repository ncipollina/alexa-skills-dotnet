using System.Text.Json;
using Alexa.NET.ConnectionTasks;

namespace Alexa.NET.Request.Type;

public interface IConnectionTaskConverter
{
    bool CanConvert(JsonElement element);
    IConnectionTask Convert(JsonElement element, JsonSerializerOptions options);
}