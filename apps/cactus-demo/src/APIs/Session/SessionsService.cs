using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class SessionsService : SessionsServiceBase
{
    public SessionsService(CactusDemoDbContext context)
        : base(context) { }
}
