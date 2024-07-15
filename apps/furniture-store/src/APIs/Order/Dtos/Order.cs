namespace FurnitureStore.APIs.Dtos;

public class Order
{
    public string Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public double? TotalAmount { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Customer { get; set; }
}
