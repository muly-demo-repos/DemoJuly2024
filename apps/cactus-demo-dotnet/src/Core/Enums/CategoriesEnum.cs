using System.Runtime.Serialization;

namespace CactusDemoDotnet.Core.Enums;

public enum CategoriesEnum
{
    [EnumMember(Value = "calendar")]
    Calendar,

    [EnumMember(Value = "messaging")]
    Messaging,

    [EnumMember(Value = "other")]
    Other,

    [EnumMember(Value = "payment")]
    Payment,

    [EnumMember(Value = "video")]
    Video,

    [EnumMember(Value = "web3")]
    Web3
}
