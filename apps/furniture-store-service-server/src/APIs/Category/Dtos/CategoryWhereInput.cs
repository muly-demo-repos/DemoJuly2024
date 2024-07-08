namespace FurnitureStoreService.APIs.Dtos;

public class CategoryWhereInput
{
    public string? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public List<string>? Products { get; set; }
}
