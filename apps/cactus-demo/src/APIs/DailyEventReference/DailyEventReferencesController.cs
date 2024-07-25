using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[ApiController()]
public class DailyEventReferencesController : DailyEventReferencesControllerBase
{
    public DailyEventReferencesController(IDailyEventReferencesService service)
        : base(service) { }
}
