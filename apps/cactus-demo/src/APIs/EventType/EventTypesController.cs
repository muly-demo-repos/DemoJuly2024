using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class EventTypesController : EventTypesControllerBase
{
    public EventTypesController(IEventTypesService service)
        : base(service) { }
}
