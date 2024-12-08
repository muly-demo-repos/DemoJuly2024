using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class DestinationCalendarsService : DestinationCalendarsServiceBase
{
    public DestinationCalendarsService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
