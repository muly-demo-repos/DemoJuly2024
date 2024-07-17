namespace CactusDemoDotnet.APIs.Dtos;

public class DestinationCalendarWhereInput
{
    public int? Id { get; set; }

    public string? Integration { get; set; }

    public string? ExternalId { get; set; }

    public int? User { get; set; }

    public int? Booking { get; set; }

    public int? EventType { get; set; }

    public int? Credential { get; set; }
}
