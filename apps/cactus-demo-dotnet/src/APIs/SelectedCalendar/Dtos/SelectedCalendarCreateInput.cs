namespace CactusDemoDotnet.APIs.Dtos;

public class SelectedCalendarCreateInput
{
    public int? Id { get; set; }

    public User User { get; set; }

    public string Integration { get; set; }

    public string ExternalId { get; set; }
}
