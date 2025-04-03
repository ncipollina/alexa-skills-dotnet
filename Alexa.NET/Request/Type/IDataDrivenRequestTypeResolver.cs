using System.Text.Json;

namespace Alexa.NET.Request.Type;

public interface IDataDrivenRequestTypeResolver : IRequestTypeResolver
{
    System.Type? Resolve(JsonElement data);
}