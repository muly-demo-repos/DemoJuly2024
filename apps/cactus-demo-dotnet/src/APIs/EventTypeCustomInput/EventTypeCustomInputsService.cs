using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class EventTypeCustomInputsService : EventTypeCustomInputsServiceBase
{
    public EventTypeCustomInputsService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
