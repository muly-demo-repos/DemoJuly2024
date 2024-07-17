using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.APIs.Dtos;

public class WorkflowReminderWhereInput
{
    public int? Id { get; set; }

    public int? Booking { get; set; }

    public MethodEnum? Method { get; set; }

    public DateTime? ScheduledDate { get; set; }

    public string? ReferenceId { get; set; }

    public bool? Scheduled { get; set; }

    public int? WorkflowStep { get; set; }
}
