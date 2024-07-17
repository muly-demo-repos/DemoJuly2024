namespace CactusDemoDotnet.APIs.Dtos;

public class Feedback
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int User { get; set; }

    public string Rating { get; set; }

    public string? Comment { get; set; }
}
