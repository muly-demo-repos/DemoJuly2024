namespace CactusDemoDotnet.APIs.Dtos;

public class HashedLinkCreateInput
{
    public int? Id { get; set; }

    public string Link { get; set; }

    public EventType EventType { get; set; }
}
