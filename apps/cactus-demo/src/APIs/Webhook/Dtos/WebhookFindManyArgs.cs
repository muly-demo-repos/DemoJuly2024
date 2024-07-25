using CactusDemo.APIs.Common;
using CactusDemo.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class WebhookFindManyArgs : FindManyInput<Webhook, WebhookWhereInput> { }
