using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class SelectedCalendarsService : SelectedCalendarsServiceBase
{
    public SelectedCalendarsService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
