using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("Workflows")]
public class WorkflowDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    [StringLength(256)]
    public string Name { get; set; }

    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel User { get; set; } = null;

    [Required()]
    public TriggerEnum Trigger { get; set; } = TriggerEnum.BEFORE_EVENT;

    [Range(0, 99999999999)]
    public int? Time { get; set; }

    public TimeUnitEnum? TimeUnit { get; set; }

    public List<WorkflowStepDbModel>? Steps { get; set; } = new List<WorkflowStepDbModel>();

    public List<WorkflowsOnEventTypeDbModel>? ActiveOn { get; set; } =
        new List<WorkflowsOnEventTypeDbModel>();
}
