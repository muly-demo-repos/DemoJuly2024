using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class AccountsService : AccountsServiceBase
{
    public AccountsService(CactusDemoDbContext context)
        : base(context) { }
}
