using System.Runtime.Serialization;

namespace CactusDemo.Core.Enums;

public enum ReminderTypeEnum
{
    [EnumMember(Value = "PENDING_BOOKING_CONFIRMATION")]
    PendingBookingConfirmation
}
