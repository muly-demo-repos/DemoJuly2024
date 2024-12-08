using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
