using System.Runtime.Serialization;

namespace CactusDemo.Core.Enums;

public enum TriggerEnum
{
    [EnumMember(Value = "BEFORE_EVENT")]
    BeforeEvent,

    [EnumMember(Value = "EVENT_CANCELLED")]
    EventCancelled,

    [EnumMember(Value = "NEW_EVENT")]
    NewEvent
}
