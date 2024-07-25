using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class MembershipsService : MembershipsServiceBase
{
    public MembershipsService(CactusDemoDbContext context)
        : base(context) { }
}
