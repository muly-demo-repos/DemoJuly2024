using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class EventTypeCustomInputsService : EventTypeCustomInputsServiceBase
{
    public EventTypeCustomInputsService(CactusDemoDbContext context)
        : base(context) { }
}
