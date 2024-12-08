using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CactusDemoDotnet.Core.Enums;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("Payments")]
public class PaymentDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    [StringLength(256)]
    public string Uid { get; set; }

    [Required()]
    public TypeEnum Type { get; set; } = TypeEnum.STRIPE;

    public int? BookingId { get; set; }

    [ForeignKey(nameof(BookingId))]
    public BookingDbModel? Booking { get; set; } = null;

    [Required()]
    [Range(0, 99999999999)]
    public int Amount { get; set; }

    [Required()]
    [Range(0, 99999999999)]
    public int Fee { get; set; }

    [Required()]
    [StringLength(256)]
    public string Currency { get; set; }

    [Required()]
    public bool Success { get; set; }

    [Required()]
    public bool Refunded { get; set; }

    [Required()]
    public string Data { get; set; }

    [Required()]
    [StringLength(256)]
    public string ExternalId { get; set; }
}
