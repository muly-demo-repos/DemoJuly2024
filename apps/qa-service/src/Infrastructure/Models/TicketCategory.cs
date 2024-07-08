using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QaService.Infrastructure.Models;

[Table("TicketCategories")]
public class TicketCategoryDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [StringLength(1000)]
    public string? CategoryName { get; set; }

    public List<TicketCriterionDbModel>? TicketCriteria { get; set; } =
        new List<TicketCriterionDbModel>();
}
