using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class CredentialsService : CredentialsServiceBase
{
    public CredentialsService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
