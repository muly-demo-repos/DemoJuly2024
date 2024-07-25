using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class DailyEventReferencesService : DailyEventReferencesServiceBase
{
    public DailyEventReferencesService(CactusDemoDbContext context)
        : base(context) { }
}
