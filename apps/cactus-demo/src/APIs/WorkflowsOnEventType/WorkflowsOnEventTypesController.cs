using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class WorkflowsOnEventTypesController : WorkflowsOnEventTypesControllerBase
{
    public WorkflowsOnEventTypesController(IWorkflowsOnEventTypesService service)
        : base(service) { }
}
