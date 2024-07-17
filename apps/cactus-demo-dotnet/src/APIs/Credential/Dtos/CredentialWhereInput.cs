namespace CactusDemoDotnet.APIs.Dtos;

public class CredentialWhereInput
{
    public int? Id { get; set; }

    public string? TypeField { get; set; }

    public string? Key { get; set; }

    public int? User { get; set; }

    public string? AppField { get; set; }

    public List<int>? DestinationCalendars { get; set; }
}
