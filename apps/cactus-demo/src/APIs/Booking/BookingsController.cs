using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class BookingsController : BookingsControllerBase
{
    public BookingsController(IBookingsService service)
        : base(service) { }
}
