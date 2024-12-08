using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using CactusDemoDotnet.APIs.Extensions;
using CactusDemoDotnet.Infrastructure;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemoDotnet.APIs;

public abstract class ApiKeysServiceBase : IApiKeysService
{
    protected readonly CactusDemoDotnetDbContext _context;

    public ApiKeysServiceBase(CactusDemoDotnetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Get a App Field record for Api Key
    /// </summary>
    public async Task<AppModel> GetAppField(ApiKeyWhereUniqueInput uniqueId)
    {
        var apiKey = await _context
            .ApiKeys.Where(apiKey => apiKey.Id == uniqueId.Id)
            .Include(apiKey => apiKey.AppField)
            .FirstOrDefaultAsync();
        if (apiKey == null)
        {
            throw new NotFoundException();
        }
        return apiKey.AppField.ToDto();
    }

    /// <summary>
    /// Get a User record for Api Key
    /// </summary>
    public async Task<User> GetUser(ApiKeyWhereUniqueInput uniqueId)
    {
        var apiKey = await _context
            .ApiKeys.Where(apiKey => apiKey.Id == uniqueId.Id)
            .Include(apiKey => apiKey.User)
            .FirstOrDefaultAsync();
        if (apiKey == null)
        {
            throw new NotFoundException();
        }
        return apiKey.User.ToDto();
    }

    /// <summary>
    /// Meta data about Api Key records
    /// </summary>
    public async Task<MetadataDto> ApiKeysMeta(ApiKeyFindManyArgs findManyArgs)
    {
        var count = await _context.ApiKeys.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Create one Api Key
    /// </summary>
    public async Task<ApiKey> CreateApiKey(ApiKeyCreateInput createDto)
    {
        var apiKey = new ApiKeyDbModel
        {
            Note = createDto.Note,
            CreatedAt = createDto.CreatedAt,
            ExpiresAt = createDto.ExpiresAt,
            LastUsedAt = createDto.LastUsedAt,
            HashedKey = createDto.HashedKey
        };

        if (createDto.Id != null)
        {
            apiKey.Id = createDto.Id;
        }
        if (createDto.User != null)
        {
            apiKey.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.AppField != null)
        {
            apiKey.AppField = await _context
                .AppModels.Where(appModel => createDto.AppField.Id == appModel.Id)
                .FirstOrDefaultAsync();
        }

        _context.ApiKeys.Add(apiKey);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ApiKeyDbModel>(apiKey.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Api Key
    /// </summary>
    public async Task DeleteApiKey(ApiKeyWhereUniqueInput uniqueId)
    {
        var apiKey = await _context.ApiKeys.FindAsync(uniqueId.Id);
        if (apiKey == null)
        {
            throw new NotFoundException();
        }

        _context.ApiKeys.Remove(apiKey);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ApiKeys
    /// </summary>
    public async Task<List<ApiKey>> ApiKeys(ApiKeyFindManyArgs findManyArgs)
    {
        var apiKeys = await _context
            .ApiKeys.Include(x => x.User)
            .Include(x => x.AppField)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return apiKeys.ConvertAll(apiKey => apiKey.ToDto());
    }

    /// <summary>
    /// Get one Api Key
    /// </summary>
    public async Task<ApiKey> ApiKey(ApiKeyWhereUniqueInput uniqueId)
    {
        var apiKeys = await this.ApiKeys(
            new ApiKeyFindManyArgs { Where = new ApiKeyWhereInput { Id = uniqueId.Id } }
        );
        var apiKey = apiKeys.FirstOrDefault();
        if (apiKey == null)
        {
            throw new NotFoundException();
        }

        return apiKey;
    }

    /// <summary>
    /// Update one Api Key
    /// </summary>
    public async Task UpdateApiKey(ApiKeyWhereUniqueInput uniqueId, ApiKeyUpdateInput updateDto)
    {
        var apiKey = updateDto.ToModel(uniqueId);

        _context.Entry(apiKey).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ApiKeys.Any(e => e.Id == apiKey.Id))
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
