namespace FurnitureStoreService.APIs.Dtos;

public class OrderUpdateInput
{
    public string? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public List<string>? OrderItems { get; set; }

    public DateTime? OrderDate { get; set; }

    public double? TotalAmount { get; set; }

    public string? Customer { get; set; }

    public string? AgentName { get; set; }

    public int? OrderPriority { get; set; }
}
