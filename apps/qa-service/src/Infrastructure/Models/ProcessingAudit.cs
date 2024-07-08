using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaService.Infrastructure.Models;

[Table("ProcessingAudits")]
public class ProcessingAuditDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [Range(0, 99999999999)]
    public int? TicketNumber { get; set; }

    [StringLength(1000)]
    public string? TypeField { get; set; }

    [StringLength(1000)]
    public string? Subtype { get; set; }

    [StringLength(1000)]
    public string? Item { get; set; }

    [StringLength(1000)]
    public string? Criteria { get; set; }

    [StringLength(1000)]
    public string? Result { get; set; }
}
