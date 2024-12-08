using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureStore.Infrastructure.Models;

[Table("Products")]
public class ProductDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [Range(-999999999, 999999999)]
    public double? Price { get; set; }

    public string? CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public CategoryDbModel? Category { get; set; } = null;

    public string? SupplierId { get; set; }

    [ForeignKey(nameof(SupplierId))]
    public SupplierDbModel? Supplier { get; set; } = null;
}
