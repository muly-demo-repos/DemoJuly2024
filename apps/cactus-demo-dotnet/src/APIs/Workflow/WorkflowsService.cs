using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class WorkflowsService : WorkflowsServiceBase
{
    public WorkflowsService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
