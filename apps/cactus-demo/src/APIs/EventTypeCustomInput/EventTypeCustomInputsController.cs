using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class EventTypeCustomInputsController : EventTypeCustomInputsControllerBase
{
    public EventTypeCustomInputsController(IEventTypeCustomInputsService service)
        : base(service) { }
}
