using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class WorkflowsOnEventTypesController : WorkflowsOnEventTypesControllerBase
{
    public WorkflowsOnEventTypesController(IWorkflowsOnEventTypesService service)
        : base(service) { }
}
