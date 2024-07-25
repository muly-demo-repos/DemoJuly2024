using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class WorkflowsService : WorkflowsServiceBase
{
    public WorkflowsService(CactusDemoDbContext context)
        : base(context) { }
}
