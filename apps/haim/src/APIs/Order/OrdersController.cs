using Microsoft.AspNetCore.Mvc;

namespace Haim.APIs;

[ApiController()]
public class OrdersController : OrdersControllerBase
{
    public OrdersController(IOrdersService service)
        : base(service) { }
}
