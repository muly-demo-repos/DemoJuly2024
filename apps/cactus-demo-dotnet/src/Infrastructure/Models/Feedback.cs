using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemoDotnet.Infrastructure.Models;

[Table("Feedbacks")]
public class FeedbackDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    public DateTime Date { get; set; }

    public int UserId { get; set; }

    [ForeignKey(nameof(UserId))]
    public UserDbModel User { get; set; } = null;

    [Required()]
    [StringLength(256)]
    public string Rating { get; set; }

    [StringLength(256)]
    public string? Comment { get; set; }
}
