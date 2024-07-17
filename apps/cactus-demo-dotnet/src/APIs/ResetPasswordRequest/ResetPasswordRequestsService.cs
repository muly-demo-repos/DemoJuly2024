using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class ResetPasswordRequestsService : ResetPasswordRequestsServiceBase
{
    public ResetPasswordRequestsService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
