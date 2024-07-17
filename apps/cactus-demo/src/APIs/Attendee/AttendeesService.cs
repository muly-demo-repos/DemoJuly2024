using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class AttendeesService : AttendeesServiceBase
{
    public AttendeesService(CactusDemoDbContext context)
        : base(context) { }
}
