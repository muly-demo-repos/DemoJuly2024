using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class Workflow
{
    public int Id { get; set; }

    public string Name { get; set; }

    public TriggerEnum Trigger { get; set; }

    public int? Time { get; set; }

    public TimeUnitEnum? TimeUnit { get; set; }

    public int Users { get; set; }

    public List<int>? WorkflowStep { get; set; }

    public List<int>? WorkflowsOnEventTypes { get; set; }
}
