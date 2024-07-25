using System.Runtime.Serialization;

namespace CactusDemo.Core.Enums;

public enum PeriodTypeEnum
{
    [EnumMember(Value = "UNLIMITED")]
    Unlimited,

    [EnumMember(Value = "ROLLING")]
    Rolling,

    [EnumMember(Value = "RANGE")]
    Range
}
