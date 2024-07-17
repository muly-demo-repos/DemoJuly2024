using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using CactusDemoDotnet.APIs.Extensions;
using CactusDemoDotnet.Infrastructure;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemoDotnet.APIs;

public abstract class AppModelsServiceBase : IAppModelsService
{
    protected readonly CactusDemoDotnetDbContext _context;

    public AppModelsServiceBase(CactusDemoDotnetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Connect multiple Api Key records to App Model
    /// </summary>
    public async Task ConnectApiKey(
        AppModelWhereUniqueInput uniqueId,
        ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        var appModel = await _context
            .AppModels.Include(x => x.ApiKey)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (appModel == null)
        {
            throw new NotFoundException();
        }

        var apiKeys = await _context
            .ApiKeys.Where(t => apiKeysId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (apiKeys.Count == 0)
        {
            throw new NotFoundException();
        }

        var apiKeysToConnect = apiKeys.Except(appModel.ApiKey);

        foreach (var apiKey in apiKeysToConnect)
        {
            appModel.ApiKey.Add(apiKey);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Credentials records to App Model
    /// </summary>
    public async Task ConnectCredentials(
        AppModelWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    )
    {
        var appModel = await _context
            .AppModels.Include(x => x.Credentials)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (appModel == null)
        {
            throw new NotFoundException();
        }

        var credentials = await _context
            .Credentials.Where(t => credentialsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (credentials.Count == 0)
        {
            throw new NotFoundException();
        }

        var credentialsToConnect = credentials.Except(appModel.Credentials);

        foreach (var credential in credentialsToConnect)
        {
            appModel.Credentials.Add(credential);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Webhook records to App Model
    /// </summary>
    public async Task ConnectWebhook(
        AppModelWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    )
    {
        var appModel = await _context
            .AppModels.Include(x => x.Webhook)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (appModel == null)
        {
            throw new NotFoundException();
        }

        var webhooks = await _context
            .Webhooks.Where(t => webhooksId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (webhooks.Count == 0)
        {
            throw new NotFoundException();
        }

        var webhooksToConnect = webhooks.Except(appModel.Webhook);

        foreach (var webhook in webhooksToConnect)
        {
            appModel.Webhook.Add(webhook);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Api Key records from App Model
    /// </summary>
    public async Task DisconnectApiKey(
        AppModelWhereUniqueInput uniqueId,
        ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        var appModel = await _context
            .AppModels.Include(x => x.ApiKey)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (appModel == null)
        {
            throw new NotFoundException();
        }

        var apiKeys = await _context
            .ApiKeys.Where(t => apiKeysId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var apiKey in apiKeys)
        {
            appModel.ApiKey?.Remove(apiKey);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Credentials records from App Model
    /// </summary>
    public async Task DisconnectCredentials(
        AppModelWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    )
    {
        var appModel = await _context
            .AppModels.Include(x => x.Credentials)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (appModel == null)
        {
            throw new NotFoundException();
        }

        var credentials = await _context
            .Credentials.Where(t => credentialsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var credential in credentials)
        {
            appModel.Credentials?.Remove(credential);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Webhook records from App Model
    /// </summary>
    public async Task DisconnectWebhook(
        AppModelWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    )
    {
        var appModel = await _context
            .AppModels.Include(x => x.Webhook)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (appModel == null)
        {
            throw new NotFoundException();
        }

        var webhooks = await _context
            .Webhooks.Where(t => webhooksId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var webhook in webhooks)
        {
            appModel.Webhook?.Remove(webhook);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Api Key records for App Model
    /// </summary>
    public async Task<List<ApiKey>> FindApiKey(
        AppModelWhereUniqueInput uniqueId,
        ApiKeyFindManyArgs appModelFindManyArgs
    )
    {
        var apiKeys = await _context
            .ApiKeys.Where(m => m.AppModelId == uniqueId.Id)
            .ApplyWhere(appModelFindManyArgs.Where)
            .ApplySkip(appModelFindManyArgs.Skip)
            .ApplyTake(appModelFindManyArgs.Take)
            .ApplyOrderBy(appModelFindManyArgs.SortBy)
            .ToListAsync();

        return apiKeys.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Credentials records for App Model
    /// </summary>
    public async Task<List<Credential>> FindCredentials(
        AppModelWhereUniqueInput uniqueId,
        CredentialFindManyArgs appModelFindManyArgs
    )
    {
        var credentials = await _context
            .Credentials.Where(m => m.AppModelId == uniqueId.Id)
            .ApplyWhere(appModelFindManyArgs.Where)
            .ApplySkip(appModelFindManyArgs.Skip)
            .ApplyTake(appModelFindManyArgs.Take)
            .ApplyOrderBy(appModelFindManyArgs.SortBy)
            .ToListAsync();

        return credentials.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Webhook records for App Model
    /// </summary>
    public async Task<List<Webhook>> FindWebhook(
        AppModelWhereUniqueInput uniqueId,
        WebhookFindManyArgs appModelFindManyArgs
    )
    {
        var webhooks = await _context
            .Webhooks.Where(m => m.AppModelId == uniqueId.Id)
            .ApplyWhere(appModelFindManyArgs.Where)
            .ApplySkip(appModelFindManyArgs.Skip)
            .ApplyTake(appModelFindManyArgs.Take)
            .ApplyOrderBy(appModelFindManyArgs.SortBy)
            .ToListAsync();

        return webhooks.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Meta data about App Model records
    /// </summary>
    public async Task<MetadataDto> AppModelsMeta(AppModelFindManyArgs findManyArgs)
    {
        var count = await _context.AppModels.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update multiple Api Key records for App Model
    /// </summary>
    public async Task UpdateApiKey(
        AppModelWhereUniqueInput uniqueId,
        ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        var appModel = await _context
            .AppModels.Include(t => t.ApiKey)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (appModel == null)
        {
            throw new NotFoundException();
        }

        var apiKeys = await _context
            .ApiKeys.Where(a => apiKeysId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (apiKeys.Count == 0)
        {
            throw new NotFoundException();
        }

        appModel.ApiKey = apiKeys;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Credentials records for App Model
    /// </summary>
    public async Task UpdateCredentials(
        AppModelWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    )
    {
        var appModel = await _context
            .AppModels.Include(t => t.Credentials)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (appModel == null)
        {
            throw new NotFoundException();
        }

        var credentials = await _context
            .Credentials.Where(a => credentialsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (credentials.Count == 0)
        {
            throw new NotFoundException();
        }

        appModel.Credentials = credentials;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Webhook records for App Model
    /// </summary>
    public async Task UpdateWebhook(
        AppModelWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    )
    {
        var appModel = await _context
            .AppModels.Include(t => t.Webhook)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (appModel == null)
        {
            throw new NotFoundException();
        }

        var webhooks = await _context
            .Webhooks.Where(a => webhooksId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (webhooks.Count == 0)
        {
            throw new NotFoundException();
        }

        appModel.Webhook = webhooks;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Create one App Model
    /// </summary>
    public async Task<AppModel> CreateAppModel(AppModelCreateInput createDto)
    {
        var appModel = new AppModelDbModel
        {
            DirName = createDto.DirName,
            Keys = createDto.Keys,
            Categories = createDto.Categories,
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            appModel.Id = createDto.Id;
        }
        if (createDto.Credentials != null)
        {
            appModel.Credentials = await _context
                .Credentials.Where(credential =>
                    createDto.Credentials.Select(t => t.Id).Contains(credential.Id)
                )
                .ToListAsync();
        }

        if (createDto.Webhook != null)
        {
            appModel.Webhook = await _context
                .Webhooks.Where(webhook => createDto.Webhook.Select(t => t.Id).Contains(webhook.Id))
                .ToListAsync();
        }

        if (createDto.ApiKey != null)
        {
            appModel.ApiKey = await _context
                .ApiKeys.Where(apiKey => createDto.ApiKey.Select(t => t.Id).Contains(apiKey.Id))
                .ToListAsync();
        }

        _context.AppModels.Add(appModel);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<AppModelDbModel>(appModel.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one App Model
    /// </summary>
    public async Task DeleteAppModel(AppModelWhereUniqueInput uniqueId)
    {
        var appModel = await _context.AppModels.FindAsync(uniqueId.Id);
        if (appModel == null)
        {
            throw new NotFoundException();
        }

        _context.AppModels.Remove(appModel);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many AppModels
    /// </summary>
    public async Task<List<AppModel>> AppModels(AppModelFindManyArgs findManyArgs)
    {
        var appModels = await _context
            .AppModels.Include(x => x.Credentials)
            .Include(x => x.Webhook)
            .Include(x => x.ApiKey)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return appModels.ConvertAll(appModel => appModel.ToDto());
    }

    /// <summary>
    /// Get one App Model
    /// </summary>
    public async Task<AppModel> AppModel(AppModelWhereUniqueInput uniqueId)
    {
        var appModels = await this.AppModels(
            new AppModelFindManyArgs { Where = new AppModelWhereInput { Id = uniqueId.Id } }
        );
        var appModel = appModels.FirstOrDefault();
        if (appModel == null)
        {
            throw new NotFoundException();
        }

        return appModel;
    }

    /// <summary>
    /// Update one App Model
    /// </summary>
    public async Task UpdateAppModel(
        AppModelWhereUniqueInput uniqueId,
        AppModelUpdateInput updateDto
    )
    {
        var appModel = updateDto.ToModel(uniqueId);

        if (updateDto.Credentials != null)
        {
            appModel.Credentials = await _context
                .Credentials.Where(credential =>
                    updateDto.Credentials.Select(t => t).Contains(credential.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Webhook != null)
        {
            appModel.Webhook = await _context
                .Webhooks.Where(webhook => updateDto.Webhook.Select(t => t).Contains(webhook.Id))
                .ToListAsync();
        }

        if (updateDto.ApiKey != null)
        {
            appModel.ApiKey = await _context
                .ApiKeys.Where(apiKey => updateDto.ApiKey.Select(t => t).Contains(apiKey.Id))
                .ToListAsync();
        }

        _context.Entry(appModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.AppModels.Any(e => e.Id == appModel.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
