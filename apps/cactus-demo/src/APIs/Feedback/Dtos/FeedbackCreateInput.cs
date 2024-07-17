namespace CactusDemo.APIs.Dtos;

public class FeedbackCreateInput
{
    public int? Id { get; set; }

    public DateTime Date { get; set; }

    public string Rating { get; set; }

    public string? Comment { get; set; }

    public User Users { get; set; }
}
