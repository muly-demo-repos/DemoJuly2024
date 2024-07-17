using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class DailyEventReferencesService : DailyEventReferencesServiceBase
{
    public DailyEventReferencesService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
