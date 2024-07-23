using Moshe.Infrastructure;

namespace Moshe.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(MosheDbContext context)
        : base(context) { }
}
