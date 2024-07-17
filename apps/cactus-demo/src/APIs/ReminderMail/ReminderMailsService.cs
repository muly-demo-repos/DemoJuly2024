using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class ReminderMailsService : ReminderMailsServiceBase
{
    public ReminderMailsService(CactusDemoDbContext context)
        : base(context) { }
}
