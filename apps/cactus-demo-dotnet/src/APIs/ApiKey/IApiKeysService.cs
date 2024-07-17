using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface IApiKeysService
{
    /// <summary>
    /// Get a App Field record for Api Key
    /// </summary>
    public Task<AppModel> GetAppField(ApiKeyWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a User record for Api Key
    /// </summary>
    public Task<User> GetUser(ApiKeyWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Api Key records
    /// </summary>
    public Task<MetadataDto> ApiKeysMeta(ApiKeyFindManyArgs findManyArgs);

    /// <summary>
    /// Create one Api Key
    /// </summary>
    public Task<ApiKey> CreateApiKey(ApiKeyCreateInput apikey);

    /// <summary>
    /// Delete one Api Key
    /// </summary>
    public Task DeleteApiKey(ApiKeyWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ApiKeys
    /// </summary>
    public Task<List<ApiKey>> ApiKeys(ApiKeyFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Api Key
    /// </summary>
    public Task<ApiKey> ApiKey(ApiKeyWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Api Key
    /// </summary>
    public Task UpdateApiKey(ApiKeyWhereUniqueInput uniqueId, ApiKeyUpdateInput updateDto);
}
