using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CactusDemo.Core.Enums;

namespace CactusDemo.Infrastructure.Models;

[Table("WorkflowSteps")]
public class WorkflowStepDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    [Range(0, 99999999999)]
    public int StepNumber { get; set; }

    [Required()]
    public ActionEnum Action { get; set; } = ActionEnum.EMAIL_HOST;

    [StringLength(256)]
    public string? SendTo { get; set; }

    [StringLength(256)]
    public string? ReminderBody { get; set; }

    [StringLength(256)]
    public string? EmailSubject { get; set; }

    [Required()]
    public TemplateEnum Template { get; set; } = TemplateEnum.REMINDER;

    public int WorkflowId { get; set; }

    [ForeignKey(nameof(WorkflowId))]
    public WorkflowDbModel Workflow { get; set; } = null;

    public List<WorkflowReminderDbModel>? WorkflowReminder { get; set; } =
        new List<WorkflowReminderDbModel>();
}
