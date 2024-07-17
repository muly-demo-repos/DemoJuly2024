using CactusDemoDotnet.Infrastructure;

namespace CactusDemoDotnet.APIs;

public class FeedbacksService : FeedbacksServiceBase
{
    public FeedbacksService(CactusDemoDotnetDbContext context)
        : base(context) { }
}
