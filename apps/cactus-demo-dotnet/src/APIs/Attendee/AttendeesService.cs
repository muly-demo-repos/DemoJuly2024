using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class AttendeesService : AttendeesServiceBase
{
    public AttendeesService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
