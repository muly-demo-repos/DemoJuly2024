namespace FurnitureStoreService.APIs.Dtos;

public class OrderCreateInput
{
    public string? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<OrderItem>? OrderItems { get; set; }

    public DateTime? OrderDate { get; set; }

    public double? TotalAmount { get; set; }

    public Customer? Customer { get; set; }

    public string? AgentName { get; set; }

    public int? OrderPriority { get; set; }
}
