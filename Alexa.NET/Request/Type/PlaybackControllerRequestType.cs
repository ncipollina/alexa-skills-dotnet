using System.Runtime.Serialization;

namespace Alexa.NET.Request.Type;

public enum PlaybackControllerRequestType
{
    [EnumMember(Value = "NextCommandIssued")]
    Next,
    [EnumMember(Value = "PauseCommandIssued")]
    Pause,
    [EnumMember(Value = "PlayCommandIssued")]
    Play,
    [EnumMember(Value = "PreviousCommandIssued")]
    Previous,
    [EnumMember(Value = "Unknown")]
    Unknown
}