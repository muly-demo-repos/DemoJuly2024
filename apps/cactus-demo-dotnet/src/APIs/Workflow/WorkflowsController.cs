using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class WorkflowsController : WorkflowsControllerBase
{
    public WorkflowsController(IWorkflowsService service)
        : base(service) { }
}
