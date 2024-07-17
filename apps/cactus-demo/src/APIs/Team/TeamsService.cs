using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class TeamsService : TeamsServiceBase
{
    public TeamsService(CactusDemoDbContext context)
        : base(context) { }
}
