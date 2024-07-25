using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class AvailabilitiesService : AvailabilitiesServiceBase
{
    public AvailabilitiesService(CactusDemoDbContext context)
        : base(context) { }
}
