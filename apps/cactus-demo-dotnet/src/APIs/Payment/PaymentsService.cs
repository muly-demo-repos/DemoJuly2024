using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class PaymentsService : PaymentsServiceBase
{
    public PaymentsService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
