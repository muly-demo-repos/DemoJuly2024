using System.Runtime.Serialization;

namespace CactusDemo.Core.Enums;

public enum TemplateEnum
{
    [EnumMember(Value = "REMINDER")]
    Reminder,

    [EnumMember(Value = "CUSTOM")]
    Custom
}
