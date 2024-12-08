namespace CactusDemoDotnet.APIs.Dtos;

public class AttendeeUpdateInput
{
    public int? Id { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public string? TimeZone { get; set; }

    public string? Locale { get; set; }

    public int? Booking { get; set; }
}
