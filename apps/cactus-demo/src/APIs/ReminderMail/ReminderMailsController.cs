using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class ReminderMailsController : ReminderMailsControllerBase
{
    public ReminderMailsController(IReminderMailsService service)
        : base(service) { }
}
