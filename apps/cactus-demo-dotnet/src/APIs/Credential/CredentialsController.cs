using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class CredentialsController : CredentialsControllerBase
{
    public CredentialsController(ICredentialsService service)
        : base(service) { }
}
