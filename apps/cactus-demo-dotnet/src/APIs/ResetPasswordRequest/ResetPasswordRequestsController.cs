using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class ResetPasswordRequestsController : ResetPasswordRequestsControllerBase
{
    public ResetPasswordRequestsController(IResetPasswordRequestsService service)
        : base(service) { }
}
