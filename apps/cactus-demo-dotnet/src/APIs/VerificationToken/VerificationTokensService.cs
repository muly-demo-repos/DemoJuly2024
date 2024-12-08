using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class VerificationTokensService : VerificationTokensServiceBase
{
    public VerificationTokensService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
