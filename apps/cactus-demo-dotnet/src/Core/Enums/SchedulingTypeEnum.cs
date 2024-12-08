using System.Runtime.Serialization;

namespace CactusDemoDotnet.Core.Enums;

public enum SchedulingTypeEnum
{
    [EnumMember(Value = "ROUND_ROBIN")]
    RoundRobin,

    [EnumMember(Value = "COLLECTIVE")]
    Collective
}
