using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface IWebhooksService
{
    /// <summary>
    /// Create one Webhook
    /// </summary>
    public Task<Webhook> CreateWebhook(WebhookCreateInput webhook);

    /// <summary>
    /// Delete one Webhook
    /// </summary>
    public Task DeleteWebhook(WebhookWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Webhooks
    /// </summary>
    public Task<List<Webhook>> Webhooks(WebhookFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Webhook
    /// </summary>
    public Task<Webhook> Webhook(WebhookWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Webhook
    /// </summary>
    public Task UpdateWebhook(WebhookWhereUniqueInput uniqueId, WebhookUpdateInput updateDto);

    /// <summary>
    /// Get a App Field record for Webhook
    /// </summary>
    public Task<AppModel> GetAppField(WebhookWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Event Type record for Webhook
    /// </summary>
    public Task<EventType> GetEventType(WebhookWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a User record for Webhook
    /// </summary>
    public Task<User> GetUser(WebhookWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Webhook records
    /// </summary>
    public Task<MetadataDto> WebhooksMeta(WebhookFindManyArgs findManyArgs);
}
