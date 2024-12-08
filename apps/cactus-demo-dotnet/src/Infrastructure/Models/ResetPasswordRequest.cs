using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("ResetPasswordRequests")]
public class ResetPasswordRequestDbModel
{
    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime CreatedAt { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }

    [Required()]
    [StringLength(256)]
    public string Email { get; set; }

    [Required()]
    public DateTime Expires { get; set; }
}
