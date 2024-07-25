namespace CactusDemo.APIs.Dtos;

public class AvailabilityCreateInput
{
    public int? Id { get; set; }

    public int Days { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime? Date { get; set; }

    public EventType? EventType { get; set; }

    public Schedule? Schedule { get; set; }

    public User? Users { get; set; }
}
