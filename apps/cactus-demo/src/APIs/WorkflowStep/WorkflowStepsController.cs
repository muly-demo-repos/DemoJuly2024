using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class WorkflowStepsController : WorkflowStepsControllerBase
{
    public WorkflowStepsController(IWorkflowStepsService service)
        : base(service) { }
}
