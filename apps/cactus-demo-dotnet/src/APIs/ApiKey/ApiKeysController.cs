using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class ApiKeysController : ApiKeysControllerBase
{
    public ApiKeysController(IApiKeysService service)
        : base(service) { }
}
