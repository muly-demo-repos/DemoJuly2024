using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class CredentialsController : CredentialsControllerBase
{
    public CredentialsController(ICredentialsService service)
        : base(service) { }
}
