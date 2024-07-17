using System.Runtime.Serialization;

namespace CactusDemoDotnet.Core.Enums;

public enum PlanEnum
{
    [EnumMember(Value = "FREE")]
    Free,

    [EnumMember(Value = "TRIAL")]
    Trial,

    [EnumMember(Value = "PRO")]
    Pro
}
