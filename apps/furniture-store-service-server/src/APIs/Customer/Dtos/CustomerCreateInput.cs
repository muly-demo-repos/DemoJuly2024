namespace FurnitureStoreService.APIs.Dtos;

public class CustomerCreateInput
{
    public string? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<Order>? Orders { get; set; }
}
