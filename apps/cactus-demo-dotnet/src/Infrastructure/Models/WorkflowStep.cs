using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.Infrastructure.Models;

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

    public int WorkflowId { get; set; }

    [ForeignKey(nameof(WorkflowId))]
    public WorkflowDbModel Workflow { get; set; } = null;

    [StringLength(256)]
    public string? SendTo { get; set; }

    [StringLength(256)]
    public string? ReminderBody { get; set; }

    [StringLength(256)]
    public string? EmailSubject { get; set; }

    [Required()]
    public TemplateEnum Template { get; set; } = TemplateEnum.REMINDER;

    public List<WorkflowReminderDbModel>? WorkflowReminders { get; set; } =
        new List<WorkflowReminderDbModel>();
}
