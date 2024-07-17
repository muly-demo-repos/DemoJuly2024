using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class ResetPasswordRequestsService : ResetPasswordRequestsServiceBase
{
    public ResetPasswordRequestsService(CactusDemoDbContext context)
        : base(context) { }
}
