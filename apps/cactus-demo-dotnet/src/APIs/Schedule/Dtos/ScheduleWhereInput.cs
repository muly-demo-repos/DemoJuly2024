namespace CactusDemoDotnet.APIs.Dtos;

public class ScheduleWhereInput
{
    public int? Id { get; set; }

    public int? User { get; set; }

    public string? Name { get; set; }

    public string? TimeZone { get; set; }

    public List<int>? EventType { get; set; }

    public List<int>? Availability { get; set; }
}
