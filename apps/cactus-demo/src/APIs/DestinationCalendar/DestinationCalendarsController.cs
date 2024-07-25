using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class DestinationCalendarsController : DestinationCalendarsControllerBase
{
    public DestinationCalendarsController(IDestinationCalendarsService service)
        : base(service) { }
}
