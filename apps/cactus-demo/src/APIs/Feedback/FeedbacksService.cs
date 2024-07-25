using CactusDemo.Infrastructure;

namespace CactusDemo.APIs;

public class FeedbacksService : FeedbacksServiceBase
{
    public FeedbacksService(CactusDemoDbContext context)
        : base(context) { }
}
