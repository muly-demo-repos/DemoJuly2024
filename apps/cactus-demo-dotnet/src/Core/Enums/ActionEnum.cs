using System.Runtime.Serialization;

namespace CactusDemoDotnet.Core.Enums;

public enum ActionEnum
{
    [EnumMember(Value = "EMAIL_HOST")]
    EmailHost,

    [EnumMember(Value = "EMAIL_ATTENDEE")]
    EmailAttendee,

    [EnumMember(Value = "SMS_ATTENDEE")]
    SmsAttendee,

    [EnumMember(Value = "SMS_NUMBER")]
    SmsNumber
}
