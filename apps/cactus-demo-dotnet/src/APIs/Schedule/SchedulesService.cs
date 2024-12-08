using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class SchedulesService : SchedulesServiceBase
{
    public SchedulesService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
