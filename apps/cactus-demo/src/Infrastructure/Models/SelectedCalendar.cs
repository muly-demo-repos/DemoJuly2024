using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemo.Infrastructure.Models;

[Table("SelectedCalendars")]
public class SelectedCalendarDbModel
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

    public int UsersId { get; set; }

    [ForeignKey(nameof(UsersId))]
    public UserDbModel Users { get; set; } = null;
}
