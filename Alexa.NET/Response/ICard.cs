using System.Text.Json.Serialization;
using Alexa.NET.Response.Converters;

namespace Alexa.NET.Response;

[JsonConverter(typeof(CardConverter))]
public interface ICard : IResponse
{
}