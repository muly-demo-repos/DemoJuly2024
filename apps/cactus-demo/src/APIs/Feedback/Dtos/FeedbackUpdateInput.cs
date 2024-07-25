namespace CactusDemo.APIs.Dtos;

public class FeedbackUpdateInput
{
    public int? Id { get; set; }

    public DateTime? Date { get; set; }

    public string? Rating { get; set; }

    public string? Comment { get; set; }

    public int? Users { get; set; }
}
