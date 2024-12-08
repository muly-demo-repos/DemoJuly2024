using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class AvailabilitiesService : AvailabilitiesServiceBase
{
    public AvailabilitiesService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
