using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class WorkflowStepsController : WorkflowStepsControllerBase
{
    public WorkflowStepsController(IWorkflowStepsService service)
        : base(service) { }
}
