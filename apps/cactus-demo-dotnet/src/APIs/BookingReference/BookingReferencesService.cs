using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class BookingReferencesService : BookingReferencesServiceBase
{
    public BookingReferencesService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
