using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;

namespace CactusDemo.APIs;

public interface IAppModelsService
{
    /// <summary>
    /// Connect multiple Api Key records to App Model
    /// </summary>
    public Task ConnectApiKey(
        AppModelWhereUniqueInput uniqueId,
        ApiKeyWhereUniqueInput[] apiKeysId
    );

    /// <summary>
    /// Connect multiple Credential records to App Model
    /// </summary>
    public Task ConnectCredential(
        AppModelWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    );

    /// <summary>
    /// Connect multiple Webhook records to App Model
    /// </summary>
    public Task ConnectWebhook(
        AppModelWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    );

    /// <summary>
    /// Disconnect multiple Api Key records from App Model
    /// </summary>
    public Task DisconnectApiKey(
        AppModelWhereUniqueInput uniqueId,
        ApiKeyWhereUniqueInput[] apiKeysId
    );

    /// <summary>
    /// Disconnect multiple Credential records from App Model
    /// </summary>
    public Task DisconnectCredential(
        AppModelWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    );

    /// <summary>
    /// Disconnect multiple Webhook records from App Model
    /// </summary>
    public Task DisconnectWebhook(
        AppModelWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    );

    /// <summary>
    /// Find multiple Api Key records for App Model
    /// </summary>
    public Task<List<ApiKey>> FindApiKey(
        AppModelWhereUniqueInput uniqueId,
        ApiKeyFindManyArgs ApiKeyFindManyArgs
    );

    /// <summary>
    /// Find multiple Credential records for App Model
    /// </summary>
    public Task<List<Credential>> FindCredential(
        AppModelWhereUniqueInput uniqueId,
        CredentialFindManyArgs CredentialFindManyArgs
    );

    /// <summary>
    /// Find multiple Webhook records for App Model
    /// </summary>
    public Task<List<Webhook>> FindWebhook(
        AppModelWhereUniqueInput uniqueId,
        WebhookFindManyArgs WebhookFindManyArgs
    );

    /// <summary>
    /// Meta data about App Model records
    /// </summary>
    public Task<MetadataDto> AppModelsMeta(AppModelFindManyArgs findManyArgs);

    /// <summary>
    /// Update multiple Api Key records for App Model
    /// </summary>
    public Task UpdateApiKey(AppModelWhereUniqueInput uniqueId, ApiKeyWhereUniqueInput[] apiKeysId);

    /// <summary>
    /// Update multiple Credential records for App Model
    /// </summary>
    public Task UpdateCredential(
        AppModelWhereUniqueInput uniqueId,
        CredentialWhereUniqueInput[] credentialsId
    );

    /// <summary>
    /// Update multiple Webhook records for App Model
    /// </summary>
    public Task UpdateWebhook(
        AppModelWhereUniqueInput uniqueId,
        WebhookWhereUniqueInput[] webhooksId
    );

    /// <summary>
    /// Create one App Model
    /// </summary>
    public Task<AppModel> CreateAppModel(AppModelCreateInput appmodel);

    /// <summary>
    /// Delete one App Model
    /// </summary>
    public Task DeleteAppModel(AppModelWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many AppModels
    /// </summary>
    public Task<List<AppModel>> AppModels(AppModelFindManyArgs findManyArgs);

    /// <summary>
    /// Get one App Model
    /// </summary>
    public Task<AppModel> AppModel(AppModelWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one App Model
    /// </summary>
    public Task UpdateAppModel(AppModelWhereUniqueInput uniqueId, AppModelUpdateInput updateDto);
}
