using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureStore.Infrastructure.Models;

[Table("Suppliers")]
public class SupplierDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [StringLength(1000)]
    public string? Name { get; set; }

    [StringLength(1000)]
    public string? ContactPerson { get; set; }

    [StringLength(1000)]
    public string? Phone { get; set; }

    public string? Email { get; set; }

    public List<ProductDbModel>? Products { get; set; } = new List<ProductDbModel>();
}
