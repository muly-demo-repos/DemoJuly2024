using System.Runtime.Serialization;

namespace CactusDemo.Core.Enums;

public enum TimeUnitEnum
{
    [EnumMember(Value = "DAY")]
    Day,

    [EnumMember(Value = "HOUR")]
    Hour,

    [EnumMember(Value = "MINUTE")]
    Minute
}
