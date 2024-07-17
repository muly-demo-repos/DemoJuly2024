using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class EventTypesController : EventTypesControllerBase
{
    public EventTypesController(IEventTypesService service)
        : base(service) { }
}
