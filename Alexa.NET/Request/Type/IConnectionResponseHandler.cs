using System.Text.Json;

namespace Alexa.NET.Request.Type;

public interface IConnectionResponseHandler
{
    bool CanCreate(JsonElement element);
    System.Type Create(JsonElement element);
}