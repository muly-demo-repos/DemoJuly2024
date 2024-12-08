using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class EventTypesService : EventTypesServiceBase
{
    public EventTypesService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
