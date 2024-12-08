using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class WorkflowStepsService : WorkflowStepsServiceBase
{
    public WorkflowStepsService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
