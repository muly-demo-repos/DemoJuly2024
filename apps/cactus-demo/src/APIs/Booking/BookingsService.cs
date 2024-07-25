using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class BookingsService : BookingsServiceBase
{
    public BookingsService(CactusDemoDbContext context)
        : base(context) { }
}
