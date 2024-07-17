using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class WorkflowRemindersController : WorkflowRemindersControllerBase
{
    public WorkflowRemindersController(IWorkflowRemindersService service)
        : base(service) { }
}
