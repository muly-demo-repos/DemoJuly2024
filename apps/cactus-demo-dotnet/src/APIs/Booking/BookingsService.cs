using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class BookingsService : BookingsServiceBase
{
    public BookingsService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
