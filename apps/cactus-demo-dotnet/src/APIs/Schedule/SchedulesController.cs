using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class SchedulesController : SchedulesControllerBase
{
    public SchedulesController(ISchedulesService service)
        : base(service) { }
}
