using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaService.Infrastructure.Models;

[Table("TicketCriteria")]
public class TicketCriterionDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public string? TicketCategoryId { get; set; }

    [ForeignKey(nameof(TicketCategoryId))]
    public TicketCategoryDbModel? TicketCategory { get; set; } = null;

    [StringLength(2000)]
    public string? Criteria { get; set; }
}
