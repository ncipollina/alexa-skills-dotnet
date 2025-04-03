using System.Text.Json.Serialization;
using Alexa.NET.Response.Converters;

namespace Alexa.NET.Response;

[JsonConverter(typeof(ProgressiveResponseDirectiveConverter))]
public interface IProgressiveResponseDirective
{
    string Type { get; }
}