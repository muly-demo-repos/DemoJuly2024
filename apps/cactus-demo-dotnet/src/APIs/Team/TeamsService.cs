using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class TeamsService : TeamsServiceBase
{
    public TeamsService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
