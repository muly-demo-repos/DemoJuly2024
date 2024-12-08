using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("WorkflowsOnEventTypes")]
public class WorkflowsOnEventTypeDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    public int WorkflowId { get; set; }

    [ForeignKey(nameof(WorkflowId))]
    public WorkflowDbModel Workflow { get; set; } = null;

    public int EventTypeId { get; set; }

    [ForeignKey(nameof(EventTypeId))]
    public EventTypeDbModel EventType { get; set; } = null;
}
