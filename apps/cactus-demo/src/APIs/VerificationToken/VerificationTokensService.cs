using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class VerificationTokensService : VerificationTokensServiceBase
{
    public VerificationTokensService(CactusDemoDbContext context)
        : base(context) { }
}
