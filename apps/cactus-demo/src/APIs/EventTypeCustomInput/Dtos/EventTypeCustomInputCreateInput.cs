using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class EventTypeCustomInputCreateInput
{
    public int? Id { get; set; }

    public string Label { get; set; }

    public TypeEnum Type { get; set; }

    public bool Required { get; set; }

    public string Placeholder { get; set; }

    public EventType EventType { get; set; }
}
