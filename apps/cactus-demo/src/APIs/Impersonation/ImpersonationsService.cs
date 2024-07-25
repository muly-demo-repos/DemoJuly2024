using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class ImpersonationsService : ImpersonationsServiceBase
{
    public ImpersonationsService(CactusDemoDbContext context)
        : base(context) { }
}
