namespace CactusDemoDotnet.APIs.Dtos;

public class FeedbackCreateInput
{
    public int? Id { get; set; }

    public DateTime Date { get; set; }

    public User User { get; set; }

    public string Rating { get; set; }

    public string? Comment { get; set; }
}
