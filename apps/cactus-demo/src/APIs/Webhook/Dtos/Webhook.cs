using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class Webhook
{
    public string Id { get; set; }

    public string SubscriberUrl { get; set; }

    public string? PayloadTemplate { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool Active { get; set; }

    public EventTriggersEnum EventTriggers { get; set; }

    public string? Secret { get; set; }

    public string? AppField { get; set; }

    public int? EventType { get; set; }

    public int? Users { get; set; }
}
