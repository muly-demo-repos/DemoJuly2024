using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.APIs.Dtos;

public class WorkflowReminderCreateInput
{
    public int? Id { get; set; }

    public Booking? Booking { get; set; }

    public MethodEnum Method { get; set; }

    public DateTime ScheduledDate { get; set; }

    public string? ReferenceId { get; set; }

    public bool Scheduled { get; set; }

    public WorkflowStep WorkflowStep { get; set; }
}
