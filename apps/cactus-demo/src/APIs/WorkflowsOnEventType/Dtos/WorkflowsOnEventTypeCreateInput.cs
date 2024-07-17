namespace CactusDemo.APIs.Dtos;

public class WorkflowsOnEventTypeCreateInput
{
    public int? Id { get; set; }

    public EventType EventType { get; set; }

    public Workflow Workflow { get; set; }
}
