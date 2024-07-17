using System.Runtime.Serialization;

namespace CactusDemoDotnet.Core.Enums;

public enum TimeUnitEnum
{
    [EnumMember(Value = "DAY")]
    Day,

    [EnumMember(Value = "HOUR")]
    Hour,

    [EnumMember(Value = "MINUTE")]
    Minute
}
