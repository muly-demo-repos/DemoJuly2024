namespace CactusDemo.APIs.Dtos;

public class SelectedCalendarCreateInput
{
    public int? Id { get; set; }

    public string Integration { get; set; }

    public string ExternalId { get; set; }

    public User Users { get; set; }
}
