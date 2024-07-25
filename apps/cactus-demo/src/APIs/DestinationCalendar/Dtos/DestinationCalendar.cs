namespace CactusDemo.APIs.Dtos;

public class DestinationCalendar
{
    public int Id { get; set; }

    public string Integration { get; set; }

    public string ExternalId { get; set; }

    public int? Booking { get; set; }

    public int? Credential { get; set; }

    public int? EventType { get; set; }

    public int? Users { get; set; }
}
