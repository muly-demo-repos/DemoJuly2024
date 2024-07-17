using System.Runtime.Serialization;

namespace CactusDemoDotnet.Core.Enums;

public enum MethodEnum
{
    [EnumMember(Value = "EMAIL")]
    Email,

    [EnumMember(Value = "SMS")]
    Sms
}
