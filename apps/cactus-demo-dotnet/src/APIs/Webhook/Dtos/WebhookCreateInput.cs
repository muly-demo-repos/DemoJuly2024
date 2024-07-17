using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.APIs.Dtos;

public class WebhookCreateInput
{
    public string? Id { get; set; }

    public string SubscriberUrl { get; set; }

    public string? PayloadTemplate { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool Active { get; set; }

    public EventTriggersEnum EventTriggers { get; set; }

    public User? User { get; set; }

    public EventType? EventType { get; set; }

    public AppModel? AppField { get; set; }

    public string? Secret { get; set; }
}
