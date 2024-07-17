using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class DestinationCalendarsController : DestinationCalendarsControllerBase
{
    public DestinationCalendarsController(IDestinationCalendarsService service)
        : base(service) { }
}
