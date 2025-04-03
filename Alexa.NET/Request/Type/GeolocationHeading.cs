using System.Text.Json.Serialization;

namespace Alexa.NET.Request.Type;

public class GeolocationHeading
{
    [JsonPropertyName("directionInDegrees")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Direction { get; set; }
    [JsonPropertyName("accuracyInDegrees")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Accuracy { get; set; }
}