using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class DestinationCalendarsService : DestinationCalendarsServiceBase
{
    public DestinationCalendarsService(CactusDemoDbContext context)
        : base(context) { }
}
