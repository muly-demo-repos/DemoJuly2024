using Microsoft.AspNetCore.Mvc;

namespace Haim.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
