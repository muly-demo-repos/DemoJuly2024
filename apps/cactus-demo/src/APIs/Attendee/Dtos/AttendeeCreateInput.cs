namespace CactusDemo.APIs.Dtos;

public class AttendeeCreateInput
{
    public int? Id { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }

    public string TimeZone { get; set; }

    public string? Locale { get; set; }

    public Booking? Booking { get; set; }
}
