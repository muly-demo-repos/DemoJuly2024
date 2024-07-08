namespace FurnitureStoreService.APIs.Dtos;

public class OrderItemCreateInput
{
    public string? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public double? Price { get; set; }

    public int? Quantity { get; set; }

    public Order? Order { get; set; }

    public Product? Product { get; set; }
}
