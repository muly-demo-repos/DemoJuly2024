namespace FurnitureStore.APIs.Dtos;

public class ProductWhereInput
{
    public string? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Description { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public string? Category { get; set; }

    public string? Supplier { get; set; }
}
