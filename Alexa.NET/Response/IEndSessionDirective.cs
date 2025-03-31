using System.Text.Json.Serialization;

namespace Alexa.NET.Response;

public interface IEndSessionDirective: IDirective
{
    [JsonIgnore]
    bool? ShouldEndSession { get; }
}