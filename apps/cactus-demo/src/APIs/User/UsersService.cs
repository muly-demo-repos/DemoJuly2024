using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class UsersService : UsersServiceBase
{
    public UsersService(CactusDemoDbContext context)
        : base(context) { }
}
