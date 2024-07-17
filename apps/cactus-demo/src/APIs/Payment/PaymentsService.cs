using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class PaymentsService : PaymentsServiceBase
{
    public PaymentsService(CactusDemoDbContext context)
        : base(context) { }
}
