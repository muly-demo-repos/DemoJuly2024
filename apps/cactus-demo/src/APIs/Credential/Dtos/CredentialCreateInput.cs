namespace CactusDemo.APIs.Dtos;

public class CredentialCreateInput
{
    public int? Id { get; set; }

    public string TypeField { get; set; }

    public string Key { get; set; }

    public AppModel? AppField { get; set; }

    public User? Users { get; set; }

    public List<DestinationCalendar>? DestinationCalendar { get; set; }
}
