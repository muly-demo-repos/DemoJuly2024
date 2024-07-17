using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class MembershipsService : MembershipsServiceBase
{
    public MembershipsService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
