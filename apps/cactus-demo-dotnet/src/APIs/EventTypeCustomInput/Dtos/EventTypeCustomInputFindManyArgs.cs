using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class EventTypeCustomInputFindManyArgs
    : FindManyInput<EventTypeCustomInput, EventTypeCustomInputWhereInput> { }
