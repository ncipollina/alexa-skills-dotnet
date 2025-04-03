using Alexa.NET.Request.Type;

namespace Alexa.NET.Tests;

public class NewIntentRequestTypeResolver : IRequestTypeResolver
{
    public bool CanResolve(string requestType)
    {
        return requestType == "AlexaNet.CustomIntent";
    }

    public System.Type Resolve(string requestType)
    {
        return typeof(NewIntentRequest);
    }
}