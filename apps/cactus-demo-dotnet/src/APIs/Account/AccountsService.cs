using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class AccountsService : AccountsServiceBase
{
    public AccountsService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
