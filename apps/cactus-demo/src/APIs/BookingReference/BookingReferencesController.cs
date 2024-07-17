using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class BookingReferencesController : BookingReferencesControllerBase
{
    public BookingReferencesController(IBookingReferencesService service)
        : base(service) { }
}
