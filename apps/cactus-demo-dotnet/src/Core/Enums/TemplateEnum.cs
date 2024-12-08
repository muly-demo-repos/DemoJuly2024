using System.Runtime.Serialization;

namespace CactusDemoDotnet.Core.Enums;

public enum TemplateEnum
{
    [EnumMember(Value = "REMINDER")]
    Reminder,

    [EnumMember(Value = "CUSTOM")]
    Custom
}
