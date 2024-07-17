namespace CactusDemo.APIs.Dtos;

public class DestinationCalendarCreateInput
{
    public int? Id { get; set; }

    public string Integration { get; set; }

    public string ExternalId { get; set; }

    public Booking? Booking { get; set; }

    public Credential? Credential { get; set; }

    public EventType? EventType { get; set; }

    public User? Users { get; set; }
}
