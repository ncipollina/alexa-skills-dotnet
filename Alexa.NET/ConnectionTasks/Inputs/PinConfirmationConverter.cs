using System.Text.Json;
using Alexa.NET.Request.Type;

namespace Alexa.NET.ConnectionTasks.Inputs;

public class PinConfirmationConverter : IConnectionTaskConverter
{
    public bool CanConvert(JsonElement element)
    {
        return element.TryGetProperty("uri", out var uriProp) &&
               uriProp.GetString() == PinConfirmation.AssociatedUri;
    }
    public IConnectionTask Convert(JsonElement element, JsonSerializerOptions options)
    {
        var task = JsonSerializer.Deserialize<PinConfirmation>(element.GetRawText(), options);
        return task!;
    }

    public static PinConfirmationResult? ResultFromSessionResumed(SessionResumedRequest request)
    {
        if (request.Cause.Result is JsonElement element)
        {
            return element.Deserialize<PinConfirmationResult>();
        }

        return null;
    }}