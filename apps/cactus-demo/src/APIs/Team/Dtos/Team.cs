namespace CactusDemo.APIs.Dtos;

public class Team
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Slug { get; set; }

    public string? Logo { get; set; }

    public string? Bio { get; set; }

    public bool HideBranding { get; set; }

    public List<int>? EventType { get; set; }

    public List<int>? Membership { get; set; }
}
