using System.Runtime.Serialization;

namespace CactusDemoDotnet.Core.Enums;

public enum RoleEnum
{
    [EnumMember(Value = "MEMBER")]
    Member,

    [EnumMember(Value = "ADMIN")]
    Admin,

    [EnumMember(Value = "OWNER")]
    Owner
}
