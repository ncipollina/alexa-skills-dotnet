using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Alexa.NET.Response.Directive;

public static class ConnectionSendRequestFactory
{
    public static List<IConnectionSendRequestHandler> Handlers = new List<IConnectionSendRequestHandler>
    {
        new AskForPermissionDirectiveHandler()
    };


    public static Type Create(JsonElement data)
    {
        var handler = Handlers.FirstOrDefault(h => h.CanCreate(data));

        if (handler == null)
        {
            throw new InvalidOperationException("Unable to parse Connections.SendRequest directive");
        }

        return handler.Create();
    }
}