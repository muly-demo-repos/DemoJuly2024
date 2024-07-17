using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class AccountsController : AccountsControllerBase
{
    public AccountsController(IAccountsService service)
        : base(service) { }
}
