using System.Runtime.Serialization;

namespace Alexa.NET.Request.Type;

public enum Reason
{
    [EnumMember(Value = "USER_INITIATED")]
    UserInitiated,
    [EnumMember(Value = "ERROR")]
    Error,
    [EnumMember(Value = "EXCEEDED_MAX_REPROMPTS")]
    ExceededMaxReprompts
}