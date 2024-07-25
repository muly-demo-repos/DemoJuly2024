using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class WorkflowStepUpdateInput
{
    public int? Id { get; set; }

    public int? StepNumber { get; set; }

    public ActionEnum? Action { get; set; }

    public string? SendTo { get; set; }

    public string? ReminderBody { get; set; }

    public string? EmailSubject { get; set; }

    public TemplateEnum? Template { get; set; }

    public int? Workflow { get; set; }

    public List<int>? WorkflowReminder { get; set; }
}
