using Haim.Infrastructure;

namespace Haim.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(HaimDbContext context)
        : base(context) { }
}
