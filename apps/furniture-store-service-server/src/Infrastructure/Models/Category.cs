using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureStoreService.Infrastructure.Models;

[Table("Categories")]
public class CategoryDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    public List<ProductDbModel>? Products { get; set; } = new List<ProductDbModel>();
}
