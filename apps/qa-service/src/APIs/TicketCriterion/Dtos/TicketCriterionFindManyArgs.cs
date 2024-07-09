using Microsoft.AspNetCore.Mvc;
using QaService.APIs.Common;
using QaService.Infrastructure.Models;

namespace QaService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class TicketCriterionFindManyArgs
    : FindManyInput<TicketCriterion, TicketCriterionWhereInput> { }