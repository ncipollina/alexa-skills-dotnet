using System.Text.Json.Serialization;
using Alexa.NET.Response.Converters;

namespace Alexa.NET.Response;

[JsonConverter(typeof(DirectiveConverter))]
public interface IDirective
{
    string Type { get; }
}