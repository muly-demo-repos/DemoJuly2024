using System.Runtime.Serialization;

namespace CactusDemoDotnet.Core.Enums;

public enum StatusEnum
{
    [EnumMember(Value = "CANCELLED")]
    Cancelled,

    [EnumMember(Value = "ACCEPTED")]
    Accepted,

    [EnumMember(Value = "REJECTED")]
    Rejected,

    [EnumMember(Value = "PENDING")]
    Pending
}
