using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("Webhooks")]
public class WebhookDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    [StringLength(256)]
    public string SubscriberUrl { get; set; }

    [StringLength(256)]
    public string? PayloadTemplate { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public bool Active { get; set; }

    [Required()]
    public EventTriggersEnum EventTriggers { get; set; } = EventTriggersEnum.BOOKING_CREATED;

    public int? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;

    public int? EventTypeId { get; set; }

    [ForeignKey(nameof(EventTypeId))]
    public EventTypeDbModel? EventType { get; set; } = null;

    public string? AppFieldId { get; set; }

    [ForeignKey(nameof(AppFieldId))]
    public AppModelDbModel? AppField { get; set; } = null;

    [StringLength(256)]
    public string? Secret { get; set; }
}
