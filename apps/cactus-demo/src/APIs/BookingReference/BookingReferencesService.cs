using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class BookingReferencesService : BookingReferencesServiceBase
{
    public BookingReferencesService(CactusDemoDbContext context)
        : base(context) { }
}
