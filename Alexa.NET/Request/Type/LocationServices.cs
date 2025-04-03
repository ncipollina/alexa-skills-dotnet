using System.Text.Json.Serialization;
using Alexa.NET.Response.Converters;

namespace Alexa.NET.Request.Type;

public class LocationServices
{
    [JsonPropertyName("access")]
    [JsonConverter(typeof(JsonStringEnumConverterWithEnumMemberAttrSupport<LocationServiceAccess>))]
    public LocationServiceAccess Access { get; set; }

    [JsonPropertyName("status")]
    [JsonConverter(typeof(JsonStringEnumConverterWithEnumMemberAttrSupport<LocationServiceStatus>))]
    public LocationServiceStatus Status { get; set; }
}