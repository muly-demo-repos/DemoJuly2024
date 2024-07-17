using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class SchedulesController : SchedulesControllerBase
{
    public SchedulesController(ISchedulesService service)
        : base(service) { }
}
