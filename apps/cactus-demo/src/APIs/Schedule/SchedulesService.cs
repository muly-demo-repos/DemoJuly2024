using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class SchedulesService : SchedulesServiceBase
{
    public SchedulesService(CactusDemoDbContext context)
        : base(context) { }
}
