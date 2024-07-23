using Microsoft.AspNetCore.Mvc;
using Moshe.APIs.Common;
using Moshe.Infrastructure.Models;

namespace Moshe.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class CustomerFindManyArgs : FindManyInput<Customer, CustomerWhereInput> { }
