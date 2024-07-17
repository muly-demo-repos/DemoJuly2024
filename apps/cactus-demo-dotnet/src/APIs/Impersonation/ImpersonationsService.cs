using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class ImpersonationsService : ImpersonationsServiceBase
{
    public ImpersonationsService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
