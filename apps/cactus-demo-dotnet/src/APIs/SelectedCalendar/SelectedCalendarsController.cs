using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class SelectedCalendarsController : SelectedCalendarsControllerBase
{
    public SelectedCalendarsController(ISelectedCalendarsService service)
        : base(service) { }
}
