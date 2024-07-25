using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class WorkflowsController : WorkflowsControllerBase
{
    public WorkflowsController(IWorkflowsService service)
        : base(service) { }
}
