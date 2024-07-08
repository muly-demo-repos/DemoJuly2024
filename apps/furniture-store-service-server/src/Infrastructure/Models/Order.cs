using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureStoreService.Infrastructure.Models;

[Table("Orders")]
public class OrderDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public List<OrderItemDbModel>? OrderItems { get; set; } = new List<OrderItemDbModel>();

    public DateTime? OrderDate { get; set; }

    [Range(-999999999, 999999999)]
    public double? TotalAmount { get; set; }

    public string? CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public CustomerDbModel? Customer { get; set; } = null;

    [StringLength(1000)]
    public string? AgentName { get; set; }

    [Range(1, 100)]
    public int? OrderPriority { get; set; }
}
