using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class WorkflowsOnEventTypesService : WorkflowsOnEventTypesServiceBase
{
    public WorkflowsOnEventTypesService(CactusDemoDbContext context)
        : base(context) { }
}
