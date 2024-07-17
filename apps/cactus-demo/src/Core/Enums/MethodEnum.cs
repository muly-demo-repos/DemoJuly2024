using System.Runtime.Serialization;

namespace CactusDemo.Core.Enums;

public enum MethodEnum
{
    [EnumMember(Value = "EMAIL")]
    Email,

    [EnumMember(Value = "SMS")]
    Sms
}
