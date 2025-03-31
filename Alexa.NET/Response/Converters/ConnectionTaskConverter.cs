using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Alexa.NET.ConnectionTasks;
using Alexa.NET.ConnectionTasks.Inputs;
using Alexa.NET.Request.Type;

namespace Alexa.NET.Response.Converters;

public class ConnectionTaskConverter : BasePolymorphicConverter<IConnectionTask>
{
    // public static Dictionary<string, Func<IConnectionTask>> TaskFactoryFromUri = new Dictionary<string, Func<IConnectionTask>>
    // {
    //     {"PrintPDFRequest/1",() => new PrintPdfV1() },
    //     {"PrintImageRequest/1", () => new PrintImageV1() },
    //     {"PrintWebPageRequest/1",() => new PrintWebPageV1()},
    //     {"ScheduleTaxiReservationRequest/1",() => new ScheduleTaxiReservation() },
    //     {"ScheduleFoodEstablishmentReservationRequest/1",() => new ScheduleFoodEstablishmentReservation()}
    // };
    //
    // public static readonly List<IConnectionTaskConverter> ConnectionTaskConverters = new List<IConnectionTaskConverter>();
    //
    // public override bool CanRead => true;
    // public override bool CanWrite => false;
    //
    // public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    // {
    //     var jsonObject = JObject.Load(reader);
    //     IConnectionTask directive;
    //
    //     // Check task factories
    //     var typeKey = jsonObject.Value<string>("@type");
    //     var versionKey = jsonObject.Value<string>("@version");
    //     var factoryKey = $"{typeKey}/{versionKey}";
    //     var hasFactory = TaskFactoryFromUri.ContainsKey(factoryKey);
    //     if(hasFactory)
    //     {
    //         directive = TaskFactoryFromUri[factoryKey]();
    //     }
    //     else
    //     {
    //         // Check task converters
    //         var converter = ConnectionTaskConverters.FirstOrDefault(c => c.CanConvert(jsonObject));
    //         if(converter is null) 
    //             throw new Exception(
    //                 $"unable to deserialize response. " +
    //                 $"unrecognized task type '{typeKey}' with version '{versionKey}'"
    //             );
    //         directive = converter.Convert(jsonObject);
    //     }
    //             
    //
    //     serializer.Populate(jsonObject.CreateReader(), directive);
    //
    //     return directive;
    // }
    //
    // public override bool CanConvert(Type objectType)
    // {
    //     return objectType == typeof(IConnectionTask);
    // }

    private static readonly List<IConnectionTaskConverter> ConnectionTaskConverters = [new PinConfirmationConverter()];

    public static void AddToConnectionTaskConverters(IConnectionTaskConverter converter)
    {
        if (ConnectionTaskConverters.All(rc => rc.GetType() != converter.GetType()))
        {
            ConnectionTaskConverters.Add(converter);
        }
    }

    public override IConnectionTask? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Invalid JSON format");
        }

        using var document = JsonDocument.ParseValue(ref reader);
        var root = document.RootElement;

        // Look for @type and @version
        var typeName = root.TryGetProperty(TypeDiscriminatorPropertyName, out var typeProp)
            ? typeProp.GetString()
            : null;

        var versionName = root.TryGetProperty("@version", out var versionProp)
            ? versionProp.GetString()
            : null;

        var versionKey = $"{typeName}/{versionName}";

        // First, try DerivedTypes dictionary
        if (DerivedTypes.TryGetValue(versionKey, out var resultType))
        {
            return (IConnectionTask)JsonSerializer.Deserialize(root.GetRawText(), resultType, options)!;
        }

        // If not found, try each registered custom converter
        foreach (var converter in ConnectionTaskConverters)
        {
            if (converter.CanConvert(root))
            {
                return converter.Convert(root, options);
            }
        }

        throw new JsonException(
            $"Unable to deserialize response. Unrecognized task type '{typeName}' with version '{versionName}'"
        );
    }

    protected override Func<JsonElement, string?> KeyResolver => element =>
    {
        // Look for @type and @version
        var typeName = element.TryGetProperty(TypeDiscriminatorPropertyName, out var typeProp)
            ? typeProp.GetString()
            : null;

        var versionName = element.TryGetProperty("@version", out var versionProp)
            ? versionProp.GetString()
            : null;

        if (string.IsNullOrWhiteSpace(typeName) || string.IsNullOrWhiteSpace(versionName))
            return null;
        
        return $"{typeName}/{versionName}";
    };

    protected override string TypeDiscriminatorPropertyName => "@type";

    protected override IDictionary<string, Type> DerivedTypes => new Dictionary<string, Type>
    {
        { PrintPdfV1.ConnectionKey, typeof(PrintPdfV1) },
        { PrintImageV1.ConnectionKey, typeof(PrintImageV1) },
        { PrintWebPageV1.ConnectionKey, typeof(PrintWebPageV1) },
        { ScheduleTaxiReservation.ConnectionKey, typeof(ScheduleTaxiReservation) },
        { ScheduleFoodEstablishmentReservation.ConnectionKey, typeof(ScheduleFoodEstablishmentReservation) }
    };

    protected override IDictionary<string, Func<JsonElement, Type>> DataDrivenTypeFactories { get; }

    public override Type? DefaultType => null;
}