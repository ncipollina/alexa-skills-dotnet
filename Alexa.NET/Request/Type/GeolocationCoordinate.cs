using System.Text.Json.Serialization;

namespace Alexa.NET.Request.Type;

public class GeolocationCoordinate
{
    [JsonPropertyName("latitudeInDegrees")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitudeInDegrees")]
    public double Longitude { get; set; }

    [JsonPropertyName("accuracyInMeters")]
    public double Accuracy { get; set; }
}