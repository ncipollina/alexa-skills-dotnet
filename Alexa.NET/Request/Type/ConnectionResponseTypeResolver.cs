﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Alexa.NET.Request.Type;

public class ConnectionResponseTypeResolver : IDataDrivenRequestTypeResolver
{
    public static List<IConnectionResponseHandler> Handlers = [new AskForRequestHandler()];
    public bool CanResolve(string requestType)
    {
        return requestType == "Connections.Response";
    }

    public System.Type? Resolve(string requestType)
    {
        throw new NotImplementedException();
    }

    public System.Type? Resolve(JsonElement data)
    {
        var handler = Handlers.FirstOrDefault(h => h.CanCreate(data));
        return handler?.Create(data);
    }
}