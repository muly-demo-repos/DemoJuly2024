using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class AccountsController : AccountsControllerBase
{
    public AccountsController(IAccountsService service)
        : base(service) { }
}
