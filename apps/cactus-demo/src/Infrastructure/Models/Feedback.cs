using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CactusDemo.Infrastructure.Models;

[Table("Feedbacks")]
public class FeedbackDbModel
{
    [Key()]
    [Required()]
    public int Id { get; set; }

    [Required()]
    public DateTime Date { get; set; }

    [Required()]
    [StringLength(256)]
    public string Rating { get; set; }

    [StringLength(256)]
    public string? Comment { get; set; }

    public int UsersId { get; set; }

    [ForeignKey(nameof(UsersId))]
    public UserDbModel Users { get; set; } = null;
}
