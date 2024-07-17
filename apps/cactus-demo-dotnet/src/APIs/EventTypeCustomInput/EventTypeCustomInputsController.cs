using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class EventTypeCustomInputsController : EventTypeCustomInputsControllerBase
{
    public EventTypeCustomInputsController(IEventTypeCustomInputsService service)
        : base(service) { }
}
