using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class HashedLinksService : HashedLinksServiceBase
{
    public HashedLinksService(CactusDemoDbContext context)
        : base(context) { }
}
