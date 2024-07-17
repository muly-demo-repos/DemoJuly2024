namespace CactusDemo.APIs.Dtos;

public class ScheduleWhereInput
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? TimeZone { get; set; }

    public int? Users { get; set; }

    public List<int>? Availability { get; set; }

    public List<int>? EventType { get; set; }
}
