using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class PaymentsController : PaymentsControllerBase
{
    public PaymentsController(IPaymentsService service)
        : base(service) { }
}
