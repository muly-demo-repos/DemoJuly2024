using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class SessionsService : SessionsServiceBase
{
    public SessionsService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
