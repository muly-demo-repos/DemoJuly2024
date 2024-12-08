namespace CactusDemoDotnet.APIs.Dtos;

public class SelectedCalendarWhereInput
{
    public int? Id { get; set; }

    public int? User { get; set; }

    public string? Integration { get; set; }

    public string? ExternalId { get; set; }
}
