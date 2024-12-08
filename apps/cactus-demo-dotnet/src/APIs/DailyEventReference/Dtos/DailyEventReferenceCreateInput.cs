namespace CactusDemoDotnet.APIs.Dtos;

public class DailyEventReferenceCreateInput
{
    public int? Id { get; set; }

    public string Dailyurl { get; set; }

    public string Dailytoken { get; set; }

    public Booking? Booking { get; set; }
}
