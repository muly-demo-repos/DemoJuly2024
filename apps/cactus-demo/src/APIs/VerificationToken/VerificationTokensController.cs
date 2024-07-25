using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class VerificationTokensController : VerificationTokensControllerBase
{
    public VerificationTokensController(IVerificationTokensService service)
        : base(service) { }
}
