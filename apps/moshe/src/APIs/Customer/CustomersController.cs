using Microsoft.AspNetCore.Mvc;

namespace Moshe.APIs;

[ApiController()]
public class CustomersController : CustomersControllerBase
{
    public CustomersController(ICustomersService service)
        : base(service) { }
}
