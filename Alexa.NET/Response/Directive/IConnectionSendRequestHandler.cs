using System;
using System.Text.Json;

namespace Alexa.NET.Response.Directive;

public interface IConnectionSendRequestHandler
{
    bool CanCreate(JsonElement data);

    Type Create();
}