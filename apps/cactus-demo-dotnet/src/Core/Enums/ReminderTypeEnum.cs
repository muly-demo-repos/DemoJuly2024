using System.Runtime.Serialization;

namespace CactusDemoDotnet.Core.Enums;

public enum ReminderTypeEnum
{
    [EnumMember(Value = "PENDING_BOOKING_CONFIRMATION")]
    PendingBookingConfirmation
}
