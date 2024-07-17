using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class ReminderMailsService : ReminderMailsServiceBase
{
    public ReminderMailsService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
