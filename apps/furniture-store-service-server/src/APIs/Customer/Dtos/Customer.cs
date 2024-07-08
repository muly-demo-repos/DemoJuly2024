namespace FurnitureStoreService.APIs.Dtos;

public class Customer
{
    public string Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public List<string>? Orders { get; set; }
}
