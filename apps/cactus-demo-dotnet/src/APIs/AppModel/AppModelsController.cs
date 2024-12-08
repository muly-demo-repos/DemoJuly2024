using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class AppModelsController : AppModelsControllerBase
{
    public AppModelsController(IAppModelsService service)
        : base(service) { }
}
