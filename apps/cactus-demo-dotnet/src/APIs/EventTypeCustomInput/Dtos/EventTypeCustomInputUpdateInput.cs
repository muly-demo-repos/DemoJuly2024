using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.APIs.Dtos;

public class EventTypeCustomInputUpdateInput
{
    public int? Id { get; set; }

    public int? EventType { get; set; }

    public string? Label { get; set; }

    public TypeEnum? Type { get; set; }

    public bool? Required { get; set; }

    public string? Placeholder { get; set; }
}
