using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class WorkflowRemindersService : WorkflowRemindersServiceBase
{
    public WorkflowRemindersService(CactusDemoDbContext context)
        : base(context) { }
}
