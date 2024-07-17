namespace CactusDemo.APIs.Dtos;

public class AvailabilityWhereInput
{
    public int? Id { get; set; }

    public int? Days { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public DateTime? Date { get; set; }

    public int? EventType { get; set; }

    public int? Schedule { get; set; }

    public int? Users { get; set; }
}
