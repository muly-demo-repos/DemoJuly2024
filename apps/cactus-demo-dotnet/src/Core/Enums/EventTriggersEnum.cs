using System.Runtime.Serialization;

namespace CactusDemoDotnet.Core.Enums;

public enum EventTriggersEnum
{
    [EnumMember(Value = "BOOKING_CREATED")]
    BookingCreated,

    [EnumMember(Value = "BOOKING_RESCHEDULED")]
    BookingRescheduled,

    [EnumMember(Value = "BOOKING_CANCELLED")]
    BookingCancelled
}
