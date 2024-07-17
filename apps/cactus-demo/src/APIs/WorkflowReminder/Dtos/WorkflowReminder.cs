using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class WorkflowReminder
{
    public int Id { get; set; }

    public MethodEnum Method { get; set; }

    public DateTime ScheduledDate { get; set; }

    public string? ReferenceId { get; set; }

    public bool Scheduled { get; set; }

    public int? Booking { get; set; }

    public int WorkflowStep { get; set; }
}
