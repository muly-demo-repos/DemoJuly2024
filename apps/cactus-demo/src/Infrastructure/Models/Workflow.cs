using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CactusDemo.Core.Enums;

namespace CactusDemo.Infrastructure.Models;

[Table("Workflows")]
public class WorkflowDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    [StringLength(256)]
    public string Name { get; set; }

    [Required()]
    public TriggerEnum Trigger { get; set; } = TriggerEnum.BEFORE_EVENT;

    [Range(0, 99999999999)]
    public int? Time { get; set; }

    public TimeUnitEnum? TimeUnit { get; set; }

    public int UsersId { get; set; }

    [ForeignKey(nameof(UsersId))]
    public UserDbModel Users { get; set; } = null;

    public List<WorkflowStepDbModel>? WorkflowStep { get; set; } = new List<WorkflowStepDbModel>();

    public List<WorkflowsOnEventTypeDbModel>? WorkflowsOnEventTypes { get; set; } =
        new List<WorkflowsOnEventTypeDbModel>();
}
