namespace FurnitureStore.APIs.Dtos;

public class SupplierCreateInput
{
    public string? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Name { get; set; }

    public string? ContactPerson { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public List<Product>? Products { get; set; }
}
