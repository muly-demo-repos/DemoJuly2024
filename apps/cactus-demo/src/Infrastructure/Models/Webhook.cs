using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CactusDemo.Core.Enums;

namespace CactusDemo.Infrastructure.Models;

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

    [StringLength(256)]
    public string? Secret { get; set; }

    public string? AppFieldId { get; set; }

    [ForeignKey(nameof(AppFieldId))]
    public AppModelDbModel? AppField { get; set; } = null;

    public int? EventTypeId { get; set; }

    [ForeignKey(nameof(EventTypeId))]
    public EventTypeDbModel? EventType { get; set; } = null;

    public int? UsersId { get; set; }

    [ForeignKey(nameof(UsersId))]
    public UserDbModel? Users { get; set; } = null;
}
