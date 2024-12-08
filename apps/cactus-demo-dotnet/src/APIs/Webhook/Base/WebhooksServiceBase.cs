using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using CactusDemoDotnet.APIs.Extensions;
using CactusDemoDotnet.Infrastructure;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemoDotnet.APIs;

public abstract class WebhooksServiceBase : IWebhooksService
{
    protected readonly CactusDemoDotnetDbContext _context;

    public WebhooksServiceBase(CactusDemoDotnetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Webhook
    /// </summary>
    public async Task<Webhook> CreateWebhook(WebhookCreateInput createDto)
    {
        var webhook = new WebhookDbModel
        {
            SubscriberUrl = createDto.SubscriberUrl,
            PayloadTemplate = createDto.PayloadTemplate,
            CreatedAt = createDto.CreatedAt,
            Active = createDto.Active,
            EventTriggers = createDto.EventTriggers,
            Secret = createDto.Secret
        };

        if (createDto.Id != null)
        {
            webhook.Id = createDto.Id;
        }
        if (createDto.EventType != null)
        {
            webhook.EventType = await _context
                .EventTypes.Where(eventType => createDto.EventType.Id == eventType.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.User != null)
        {
            webhook.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.AppField != null)
        {
            webhook.AppField = await _context
                .AppModels.Where(appModel => createDto.AppField.Id == appModel.Id)
                .FirstOrDefaultAsync();
        }

        _context.Webhooks.Add(webhook);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<WebhookDbModel>(webhook.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Webhook
    /// </summary>
    public async Task DeleteWebhook(WebhookWhereUniqueInput uniqueId)
    {
        var webhook = await _context.Webhooks.FindAsync(uniqueId.Id);
        if (webhook == null)
        {
            throw new NotFoundException();
        }

        _context.Webhooks.Remove(webhook);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Webhooks
    /// </summary>
    public async Task<List<Webhook>> Webhooks(WebhookFindManyArgs findManyArgs)
    {
        var webhooks = await _context
            .Webhooks.Include(x => x.EventType)
            .Include(x => x.User)
            .Include(x => x.AppField)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return webhooks.ConvertAll(webhook => webhook.ToDto());
    }

    /// <summary>
    /// Get one Webhook
    /// </summary>
    public async Task<Webhook> Webhook(WebhookWhereUniqueInput uniqueId)
    {
        var webhooks = await this.Webhooks(
            new WebhookFindManyArgs { Where = new WebhookWhereInput { Id = uniqueId.Id } }
        );
        var webhook = webhooks.FirstOrDefault();
        if (webhook == null)
        {
            throw new NotFoundException();
        }

        return webhook;
    }

    /// <summary>
    /// Update one Webhook
    /// </summary>
    public async Task UpdateWebhook(WebhookWhereUniqueInput uniqueId, WebhookUpdateInput updateDto)
    {
        var webhook = updateDto.ToModel(uniqueId);

        _context.Entry(webhook).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Webhooks.Any(e => e.Id == webhook.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Get a App Field record for Webhook
    /// </summary>
    public async Task<AppModel> GetAppField(WebhookWhereUniqueInput uniqueId)
    {
        var webhook = await _context
            .Webhooks.Where(webhook => webhook.Id == uniqueId.Id)
            .Include(webhook => webhook.AppField)
            .FirstOrDefaultAsync();
        if (webhook == null)
        {
            throw new NotFoundException();
        }
        return webhook.AppField.ToDto();
    }

    /// <summary>
    /// Get a Event Type record for Webhook
    /// </summary>
    public async Task<EventType> GetEventType(WebhookWhereUniqueInput uniqueId)
    {
        var webhook = await _context
            .Webhooks.Where(webhook => webhook.Id == uniqueId.Id)
            .Include(webhook => webhook.EventType)
            .FirstOrDefaultAsync();
        if (webhook == null)
        {
            throw new NotFoundException();
        }
        return webhook.EventType.ToDto();
    }

    /// <summary>
    /// Get a User record for Webhook
    /// </summary>
    public async Task<User> GetUser(WebhookWhereUniqueInput uniqueId)
    {
        var webhook = await _context
            .Webhooks.Where(webhook => webhook.Id == uniqueId.Id)
            .Include(webhook => webhook.User)
            .FirstOrDefaultAsync();
        if (webhook == null)
        {
            throw new NotFoundException();
        }
        return webhook.User.ToDto();
    }

    /// <summary>
    /// Meta data about Webhook records
    /// </summary>
    public async Task<MetadataDto> WebhooksMeta(WebhookFindManyArgs findManyArgs)
    {
        var count = await _context.Webhooks.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }
}
