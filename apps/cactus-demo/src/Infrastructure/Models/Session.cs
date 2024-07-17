using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemo.Infrastructure.Models;

[Table("Sessions")]
public class SessionDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    [StringLength(256)]
    public string SessionToken { get; set; }

    [Required()]
    public DateTime Expires { get; set; }

    public int? UsersId { get; set; }

    [ForeignKey(nameof(UsersId))]
    public UserDbModel? Users { get; set; } = null;
}
