using CactusDemo.APIs.Dtos;
using CactusDemo.Infrastructure.Models;

namespace CactusDemo.APIs.Extensions;

public static class WebhooksExtensions
{
    public static Webhook ToDto(this WebhookDbModel model)
    {
        return new Webhook
        {
            Id = model.Id,
            SubscriberUrl = model.SubscriberUrl,
            PayloadTemplate = model.PayloadTemplate,
            CreatedAt = model.CreatedAt,
            Active = model.Active,
            EventTriggers = model.EventTriggers,
            Secret = model.Secret,
            AppField = model.AppFieldId,
            EventType = model.EventTypeId,
            Users = model.UsersId,
        };
    }

    public static WebhookDbModel ToModel(
        this WebhookUpdateInput updateDto,
        WebhookWhereUniqueInput uniqueId
    )
    {
        var webhook = new WebhookDbModel
        {
            Id = uniqueId.Id,
            PayloadTemplate = updateDto.PayloadTemplate,
            Secret = updateDto.Secret
        };

        // map required fields
        if (updateDto.SubscriberUrl != null)
        {
            webhook.SubscriberUrl = updateDto.SubscriberUrl;
        }
        if (updateDto.CreatedAt != null)
        {
            webhook.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.Active != null)
        {
            webhook.Active = updateDto.Active.Value;
        }
        if (updateDto.EventTriggers != null)
        {
            webhook.EventTriggers = updateDto.EventTriggers.Value;
        }

        return webhook;
    }
}
