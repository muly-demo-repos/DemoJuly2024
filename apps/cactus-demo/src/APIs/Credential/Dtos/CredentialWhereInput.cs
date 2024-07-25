namespace CactusDemo.APIs.Dtos;

public class CredentialWhereInput
{
    public int? Id { get; set; }

    public string? TypeField { get; set; }

    public string? Key { get; set; }

    public string? AppField { get; set; }

    public int? Users { get; set; }

    public List<int>? DestinationCalendar { get; set; }
}
