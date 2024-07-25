using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class AppModelsController : AppModelsControllerBase
{
    public AppModelsController(IAppModelsService service)
        : base(service) { }
}
