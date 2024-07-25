using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class EventTypesService : EventTypesServiceBase
{
    public EventTypesService(CactusDemoDbContext context)
        : base(context) { }
}
