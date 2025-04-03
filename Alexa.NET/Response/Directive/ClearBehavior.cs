using System.Runtime.Serialization;

namespace Alexa.NET.Response.Directive;

public enum ClearBehavior
{
    [EnumMember(Value = "CLEAR_ENQUEUED")]
    ClearEnqueued,
    [EnumMember(Value = "CLEAR_ALL")]
    ClearAll
}