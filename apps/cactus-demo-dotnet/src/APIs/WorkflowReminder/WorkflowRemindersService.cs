using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class WorkflowRemindersService : WorkflowRemindersServiceBase
{
    public WorkflowRemindersService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
