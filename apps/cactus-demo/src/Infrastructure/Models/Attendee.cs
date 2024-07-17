using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemo.Infrastructure.Models;

[Table("Attendees")]
public class AttendeeDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    [StringLength(256)]
    public string Email { get; set; }

    [Required()]
    [StringLength(256)]
    public string Name { get; set; }

    [Required()]
    [StringLength(256)]
    public string TimeZone { get; set; }

    [StringLength(256)]
    public string? Locale { get; set; }

    public int? BookingId { get; set; }

    [ForeignKey(nameof(BookingId))]
    public BookingDbModel? Booking { get; set; } = null;
}
