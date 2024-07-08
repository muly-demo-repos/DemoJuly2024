namespace FurnitureStoreService.APIs.Dtos;

public class CategoryCreateInput
{
    public string? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<Product>? Products { get; set; }
}
