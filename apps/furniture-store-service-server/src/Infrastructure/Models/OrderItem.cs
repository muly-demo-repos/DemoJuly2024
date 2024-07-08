using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureStoreService.Infrastructure.Models;

[Table("OrderItems")]
public class OrderItemDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [Range(-999999999, 999999999)]
    public double? Price { get; set; }

    [Range(-999999999, 999999999)]
    public int? Quantity { get; set; }

    public string? OrderId { get; set; }

    [ForeignKey(nameof(OrderId))]
    public OrderDbModel? Order { get; set; } = null;

    public string? ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public ProductDbModel? Product { get; set; } = null;
}
