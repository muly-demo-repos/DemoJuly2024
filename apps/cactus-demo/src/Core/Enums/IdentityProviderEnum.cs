using System.Runtime.Serialization;

namespace CactusDemo.Core.Enums;

public enum IdentityProviderEnum
{
    [EnumMember(Value = "CAL")]
    Cal,

    [EnumMember(Value = "GOOGLE")]
    Google,

    [EnumMember(Value = "SAML")]
    Saml
}
