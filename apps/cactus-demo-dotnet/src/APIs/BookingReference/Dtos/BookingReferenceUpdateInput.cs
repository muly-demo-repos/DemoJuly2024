namespace CactusDemoDotnet.APIs.Dtos;

public class BookingReferenceUpdateInput
{
    public int? Id { get; set; }

    public string? TypeField { get; set; }

    public string? Uid { get; set; }

    public string? MeetingId { get; set; }

    public string? MeetingPassword { get; set; }

    public string? MeetingUrl { get; set; }

    public int? Booking { get; set; }

    public string? ExternalCalendarId { get; set; }

    public bool? Deleted { get; set; }
}
