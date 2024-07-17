using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CactusDemo.Core.Enums;

namespace CactusDemo.Infrastructure.Models;

[Table("EventTypeCustomInputs")]
public class EventTypeCustomInputDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    [StringLength(256)]
    public string Label { get; set; }

    [Required()]
    public TypeEnum Type { get; set; } = TypeEnum.TEXT;

    [Required()]
    public bool Required { get; set; }

    [Required()]
    [StringLength(256)]
    public string Placeholder { get; set; }

    public int EventTypeId { get; set; }

    [ForeignKey(nameof(EventTypeId))]
    public EventTypeDbModel EventType { get; set; } = null;
}
