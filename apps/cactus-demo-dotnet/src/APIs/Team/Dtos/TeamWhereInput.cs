namespace CactusDemoDotnet.APIs.Dtos;

public class TeamWhereInput
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public string? Slug { get; set; }

    public string? Logo { get; set; }

    public string? Bio { get; set; }

    public bool? HideBranding { get; set; }

    public List<int>? EventTypes { get; set; }

    public List<int>? Members { get; set; }
}
