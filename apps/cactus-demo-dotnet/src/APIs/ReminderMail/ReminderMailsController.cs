using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class ReminderMailsController : ReminderMailsControllerBase
{
    public ReminderMailsController(IReminderMailsService service)
        : base(service) { }
}
