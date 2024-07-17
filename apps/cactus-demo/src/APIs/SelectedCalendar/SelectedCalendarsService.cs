using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class SelectedCalendarsService : SelectedCalendarsServiceBase
{
    public SelectedCalendarsService(CactusDemoDbContext context)
        : base(context) { }
}
