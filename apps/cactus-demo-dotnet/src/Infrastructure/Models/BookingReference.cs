using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("BookingReferences")]
public class BookingReferenceDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    [StringLength(256)]
    public string TypeField { get; set; }

    [Required()]
    [StringLength(256)]
    public string Uid { get; set; }

    [StringLength(256)]
    public string? MeetingId { get; set; }

    [StringLength(256)]
    public string? MeetingPassword { get; set; }

    [StringLength(256)]
    public string? MeetingUrl { get; set; }

    public int? BookingId { get; set; }

    [ForeignKey(nameof(BookingId))]
    public BookingDbModel? Booking { get; set; } = null;

    [StringLength(256)]
    public string? ExternalCalendarId { get; set; }

    public bool? Deleted { get; set; }
}
