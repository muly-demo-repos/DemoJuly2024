using System.Runtime.Serialization;

namespace CactusDemo.Core.Enums;

public enum RoleEnum
{
    [EnumMember(Value = "USER")]
    User,

    [EnumMember(Value = "ADMIN")]
    Admin
}
