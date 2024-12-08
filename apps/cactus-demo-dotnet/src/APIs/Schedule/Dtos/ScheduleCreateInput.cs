namespace CactusDemoDotnet.APIs.Dtos;

public class ScheduleCreateInput
{
    public int? Id { get; set; }

    public User User { get; set; }

    public string Name { get; set; }

    public string? TimeZone { get; set; }

    public List<EventType>? EventType { get; set; }

    public List<Availability>? Availability { get; set; }
}
