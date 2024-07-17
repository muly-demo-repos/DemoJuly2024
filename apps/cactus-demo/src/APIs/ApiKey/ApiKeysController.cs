using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class ApiKeysController : ApiKeysControllerBase
{
    public ApiKeysController(IApiKeysService service)
        : base(service) { }
}
