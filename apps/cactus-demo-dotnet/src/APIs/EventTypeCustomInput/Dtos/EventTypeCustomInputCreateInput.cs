using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.APIs.Dtos;

public class EventTypeCustomInputCreateInput
{
    public int? Id { get; set; }

    public EventType EventType { get; set; }

    public string Label { get; set; }

    public TypeEnum Type { get; set; }

    public bool Required { get; set; }

    public string Placeholder { get; set; }
}
