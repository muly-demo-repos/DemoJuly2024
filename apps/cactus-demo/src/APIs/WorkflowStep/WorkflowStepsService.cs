using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class WorkflowStepsService : WorkflowStepsServiceBase
{
    public WorkflowStepsService(CactusDemoDbContext context)
        : base(context) { }
}
