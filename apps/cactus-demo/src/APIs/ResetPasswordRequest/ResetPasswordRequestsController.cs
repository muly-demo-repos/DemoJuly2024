using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class ResetPasswordRequestsController : ResetPasswordRequestsControllerBase
{
    public ResetPasswordRequestsController(IResetPasswordRequestsService service)
        : base(service) { }
}
