namespace CactusDemo.APIs.Dtos;

public class ScheduleCreateInput
{
    public int? Id { get; set; }

    public string Name { get; set; }

    public string? TimeZone { get; set; }

    public User Users { get; set; }

    public List<Availability>? Availability { get; set; }

    public List<EventType>? EventType { get; set; }
}
