using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class WorkflowCreateInput
{
    public int? Id { get; set; }

    public string Name { get; set; }

    public TriggerEnum Trigger { get; set; }

    public int? Time { get; set; }

    public TimeUnitEnum? TimeUnit { get; set; }

    public User Users { get; set; }

    public List<WorkflowStep>? WorkflowStep { get; set; }

    public List<WorkflowsOnEventType>? WorkflowsOnEventTypes { get; set; }
}
