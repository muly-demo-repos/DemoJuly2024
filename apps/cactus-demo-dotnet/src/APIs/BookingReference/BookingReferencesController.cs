using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class BookingReferencesController : BookingReferencesControllerBase
{
    public BookingReferencesController(IBookingReferencesService service)
        : base(service) { }
}
