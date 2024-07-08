using Microsoft.AspNetCore.Mvc;

namespace QaService.APIs;

[ApiController()]
public class TicketCategoriesController : TicketCategoriesControllerBase
{
    public TicketCategoriesController(ITicketCategoriesService service)
        : base(service) { }
}
