using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemo.Infrastructure.Models;

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

    public string? AppFieldId { get; set; }

    [ForeignKey(nameof(AppFieldId))]
    public AppModelDbModel? AppField { get; set; } = null;

    public int? UsersId { get; set; }

    [ForeignKey(nameof(UsersId))]
    public UserDbModel? Users { get; set; } = null;

    public List<DestinationCalendarDbModel>? DestinationCalendar { get; set; } =
        new List<DestinationCalendarDbModel>();
}
