using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class SelectedCalendarsController : SelectedCalendarsControllerBase
{
    public SelectedCalendarsController(ISelectedCalendarsService service)
        : base(service) { }
}
