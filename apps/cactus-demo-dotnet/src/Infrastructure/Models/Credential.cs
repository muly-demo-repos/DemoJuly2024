using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("Credentials")]
public class CredentialDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    [StringLength(256)]
    public string TypeField { get; set; }

    [Required()]
    public string Key { get; set; }

    public int? UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel? User { get; set; } = null;

    public string? AppFieldId { get; set; }

    [ForeignKey(nameof(AppFieldId))]
    public AppModelDbModel? AppField { get; set; } = null;

    public List<DestinationCalendarDbModel>? DestinationCalendars { get; set; } =
        new List<DestinationCalendarDbModel>();
}
