using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemo.Infrastructure.Models;

[Table("DestinationCalendars")]
public class DestinationCalendarDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    [StringLength(256)]
    public string Integration { get; set; }

    [Required()]
    [StringLength(256)]
    public string ExternalId { get; set; }

    public int? BookingId { get; set; }

    [ForeignKey(nameof(BookingId))]
    public BookingDbModel? Booking { get; set; } = null;

    public int? CredentialId { get; set; }

    [ForeignKey(nameof(CredentialId))]
    public CredentialDbModel? Credential { get; set; } = null;

    public int? EventTypeId { get; set; }

    [ForeignKey(nameof(EventTypeId))]
    public EventTypeDbModel? EventType { get; set; } = null;

    public int? UsersId { get; set; }

    [ForeignKey(nameof(UsersId))]
    public UserDbModel? Users { get; set; } = null;
}
