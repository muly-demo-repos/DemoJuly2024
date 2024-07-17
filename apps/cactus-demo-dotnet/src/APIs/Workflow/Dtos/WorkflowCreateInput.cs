using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.APIs.Dtos;

public class WorkflowCreateInput
{
    public int? Id { get; set; }

    public string Name { get; set; }

    public User User { get; set; }

    public TriggerEnum Trigger { get; set; }

    public int? Time { get; set; }

    public TimeUnitEnum? TimeUnit { get; set; }

    public List<WorkflowStep>? Steps { get; set; }

    public List<WorkflowsOnEventType>? ActiveOn { get; set; }
}
