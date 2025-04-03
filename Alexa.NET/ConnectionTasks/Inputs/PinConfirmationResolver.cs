using System;
using System.Text.Json;
using Alexa.NET.Request.Type;

namespace Alexa.NET.ConnectionTasks.Inputs;

public class PinConfirmationResolver : IConnectionTaskResolver
{
    public bool CanResolve(JsonElement element)
    {
        return element.TryGetProperty("uri", out var uriProp) &&
               uriProp.GetString() == PinConfirmation.AssociatedUri;
    }
    public Type? Resolve(JsonElement element)
    {
        return typeof(PinConfirmation);
    }

    public static PinConfirmationResult? ResultFromSessionResumed(SessionResumedRequest request)
    {
        if (request.Cause.Result is JsonElement element)
        {
            return element.Deserialize<PinConfirmationResult>();
        }

        return null;
    }}