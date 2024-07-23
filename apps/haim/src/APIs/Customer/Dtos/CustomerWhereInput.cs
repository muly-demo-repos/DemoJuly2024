namespace Haim.APIs.Dtos;

public class CustomerWhereInput
{
    public string? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public List<string>? Orders { get; set; }
}
