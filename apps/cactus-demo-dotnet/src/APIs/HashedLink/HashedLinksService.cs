using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class HashedLinksService : HashedLinksServiceBase
{
    public HashedLinksService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
