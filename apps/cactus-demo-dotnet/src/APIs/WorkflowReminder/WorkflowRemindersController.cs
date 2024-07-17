using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class WorkflowRemindersController : WorkflowRemindersControllerBase
{
    public WorkflowRemindersController(IWorkflowRemindersService service)
        : base(service) { }
}
