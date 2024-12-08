using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class VerificationTokensController : VerificationTokensControllerBase
{
    public VerificationTokensController(IVerificationTokensService service)
        : base(service) { }
}
