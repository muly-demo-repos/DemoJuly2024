using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class UsersController : UsersControllerBase
{
    public UsersController(IUsersService service)
        : base(service) { }
}
