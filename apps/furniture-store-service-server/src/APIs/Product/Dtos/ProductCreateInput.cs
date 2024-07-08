namespace FurnitureStoreService.APIs.Dtos;

public class ProductCreateInput
{
    public string? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }

    public Category? Category { get; set; }

    public List<OrderItem>? OrderItems { get; set; }
}
