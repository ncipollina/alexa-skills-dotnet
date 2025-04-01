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
    private static readonly List<IConnectionTaskConverter> ConnectionTaskConverters = [new PinConfirmationConverter()];

    public static void AddToConnectionTaskConverters(IConnectionTaskConverter converter)
    {
        if (ConnectionTaskConverters.All(rc => rc.GetType() != converter.GetType()))
        {
            ConnectionTaskConverters.Add(converter);
        }
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

    protected override Func<JsonElement, JsonSerializerOptions, IConnectionTask?> CustomConverter =>
        (element, options) =>
        {
            // Check task converters
            var converter = ConnectionTaskConverters.FirstOrDefault(c => c.CanConvert(element));
            return converter?.Convert(element, options);
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

    protected override IDictionary<string, Func<JsonElement, Type>> DataDrivenTypeFactories =>
        new Dictionary<string, Func<JsonElement, Type>>();

    public override Type? DefaultType => null;
}