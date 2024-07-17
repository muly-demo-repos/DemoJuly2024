using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class WorkflowsOnEventTypesService : WorkflowsOnEventTypesServiceBase
{
    public WorkflowsOnEventTypesService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
