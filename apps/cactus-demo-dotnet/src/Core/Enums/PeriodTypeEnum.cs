using System.Runtime.Serialization;

namespace CactusDemoDotnet.Core.Enums;

public enum PeriodTypeEnum
{
    [EnumMember(Value = "UNLIMITED")]
    Unlimited,

    [EnumMember(Value = "ROLLING")]
    Rolling,

    [EnumMember(Value = "RANGE")]
    Range
}
