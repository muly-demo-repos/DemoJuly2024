namespace CactusDemoDotnet.APIs.Dtos;

public class FeedbackWhereInput
{
    public int? Id { get; set; }

    public DateTime? Date { get; set; }

    public int? User { get; set; }

    public string? Rating { get; set; }

    public string? Comment { get; set; }
}
