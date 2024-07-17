using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class CredentialsService : CredentialsServiceBase
{
    public CredentialsService(CactusDemoDbContext context)
        : base(context) { }
}
