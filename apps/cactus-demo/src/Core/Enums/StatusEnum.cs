using System.Runtime.Serialization;

namespace CactusDemo.Core.Enums;

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
