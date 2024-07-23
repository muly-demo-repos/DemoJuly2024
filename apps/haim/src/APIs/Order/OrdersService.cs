using Haim.Infrastructure;

namespace Haim.APIs;

public class OrdersService : OrdersServiceBase
{
    public OrdersService(HaimDbContext context)
        : base(context) { }
}
