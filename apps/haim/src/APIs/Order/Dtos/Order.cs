namespace Haim.APIs.Dtos;

public class Order
{
    public string Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? Description { get; set; }

    public string? Customer { get; set; }
}
