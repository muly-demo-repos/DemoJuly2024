using QaService.Infrastructure;

namespace QaService.APIs;

public class TicketCategoriesService : TicketCategoriesServiceBase
{
    public TicketCategoriesService(QaServiceDbContext context)
        : base(context) { }
}
