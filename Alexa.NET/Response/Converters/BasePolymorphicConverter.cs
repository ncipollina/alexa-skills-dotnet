using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Alexa.NET.Response.Converters;

public abstract class BasePolymorphicConverter<T> : JsonConverter<T>
{
    protected abstract string TypeDiscriminatorPropertyName { get; }
    protected abstract IDictionary<string, Type> DerivedTypes { get; }
    protected abstract IDictionary<string, Func<JsonElement, Type>> DataDrivenTypeFactories { get; }

    protected virtual Func<JsonElement, string?> KeyResolver => element =>
    {
        var typeValue = element.TryGetProperty(TypeDiscriminatorPropertyName, out var typeProp)
            ? typeProp.GetString()
            : null;
        return typeValue;
    };
    
    protected abstract Func<JsonElement, JsonSerializerOptions, T?>? CustomConverter { get; }

    public abstract Type? DefaultType { get; }
    // public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    // {
    //     // Clone the reader so we can try twice
    //     var readerClone = reader;
    //
    //     try
    //     {
    //         // Let System.Text.Json try its built-in polymorphic handling
    //         var result = JsonSerializer.Deserialize<T>(ref readerClone, options);
    //         if (result is not null)
    //         {
    //             reader = readerClone; // sync main reader to new position
    //             return result;
    //         }
    //     }
    //     catch (JsonException)
    //     {
    //         // fallback
    //     }
    //     
    //     if (reader.TokenType != JsonTokenType.StartObject)
    //     {
    //         throw new JsonException("Invalid JSON format");
    //     }
    //     
    //     using var document = JsonDocument.ParseValue(ref reader);
    //     var root = document.RootElement;
    //     
    //     // Look for @type and @version
    //     var typeName = root.TryGetProperty(TypeDiscriminatorPropertyName, out var typeProp)
    //         ? typeProp.GetString()
    //         : null;
    //     
    //     if (string.IsNullOrWhiteSpace(typeName) || !DerivedTypes.TryGetValue(typeName!, out var resultType))
    //     {
    //         resultType = DefaultType ?? throw new JsonException($"Type {typeName} not found");
    //     }
    //     
    //     return (T)JsonSerializer.Deserialize(root.GetRawText(), resultType, options);
    // }
    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var document = JsonDocument.ParseValue(ref reader);
        var root = document.RootElement;
    
        var typeValue = KeyResolver(root); 
    
        if (string.IsNullOrWhiteSpace(typeValue))
            throw new JsonException("Missing 'type' field");
    
        var resultType = DefaultType;
    
        if (DerivedTypes.TryGetValue(typeValue, out var type))
        {
            resultType = type;
        }
        else if (DataDrivenTypeFactories.TryGetValue(typeValue, out var dataFactory))
        {
            resultType = dataFactory(root);
        }
        
        if (resultType is null && CustomConverter is not null)
        {
            var customResult = CustomConverter(root, options);
            if (customResult is not null)
            {
                return customResult;
            }
        }

        return resultType is not null
            ? (T)JsonSerializer.Deserialize(root.GetRawText(), resultType, options)!
            : throw new JsonException($"Unrecognized type '{typeValue}'");
    }
  
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}
