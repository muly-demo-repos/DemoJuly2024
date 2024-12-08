namespace CactusDemoDotnet.APIs.Dtos;

public class CredentialCreateInput
{
    public int? Id { get; set; }

    public string TypeField { get; set; }

    public string Key { get; set; }

    public User? User { get; set; }

    public AppModel? AppField { get; set; }

    public List<DestinationCalendar>? DestinationCalendars { get; set; }
}
