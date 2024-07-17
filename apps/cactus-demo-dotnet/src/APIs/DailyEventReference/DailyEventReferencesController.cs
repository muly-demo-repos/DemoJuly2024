using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[ApiController()]
public class DailyEventReferencesController : DailyEventReferencesControllerBase
{
    public DailyEventReferencesController(IDailyEventReferencesService service)
        : base(service) { }
}
