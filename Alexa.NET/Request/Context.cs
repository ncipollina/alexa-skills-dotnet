using System.Text.Json.Serialization;
using Alexa.NET.Request.Type;

namespace Alexa.NET.Request;

public class Context
{
    [JsonPropertyName("System")]
    public AlexaSystem System { get; set; }
        
    [JsonPropertyName("AudioPlayer")]
    public PlaybackState AudioPlayer { get; set; }

    [JsonPropertyName("Geolocation")]
    public Geolocation Geolocation { get; set; }
}