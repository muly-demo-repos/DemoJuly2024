using Haim.APIs.Common;
using Haim.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Haim.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class OrderFindManyArgs : FindManyInput<Order, OrderWhereInput> { }
