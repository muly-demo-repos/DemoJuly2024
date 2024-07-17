using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class WorkflowStepCreateInput
{
    public int? Id { get; set; }

    public int StepNumber { get; set; }

    public ActionEnum Action { get; set; }

    public string? SendTo { get; set; }

    public string? ReminderBody { get; set; }

    public string? EmailSubject { get; set; }

    public TemplateEnum Template { get; set; }

    public Workflow Workflow { get; set; }

    public List<WorkflowReminder>? WorkflowReminder { get; set; }
}
