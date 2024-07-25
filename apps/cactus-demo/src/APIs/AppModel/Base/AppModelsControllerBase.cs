using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class AppModelsControllerBase : ControllerBase
{
    protected readonly IAppModelsService _service;

    public AppModelsControllerBase(IAppModelsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Connect multiple Api Key records to App Model
    /// </summary>
    [HttpPost("{Id}/apiKeys")]
    public async Task<ActionResult> ConnectApiKey(
        [FromRoute()] AppModelWhereUniqueInput uniqueId,
        [FromQuery()] ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        try
        {
            await _service.ConnectApiKey(uniqueId, apiKeysId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Credential records to App Model
    /// </summary>
    [HttpPost("{Id}/credentials")]
    public async Task<ActionResult> ConnectCredential(
        [FromRoute()] AppModelWhereUniqueInput uniqueId,
        [FromQuery()] CredentialWhereUniqueInput[] credentialsId
    )
    {
        try
        {
            await _service.ConnectCredential(uniqueId, credentialsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Webhook records to App Model
    /// </summary>
    [HttpPost("{Id}/webhooks")]
    public async Task<ActionResult> ConnectWebhook(
        [FromRoute()] AppModelWhereUniqueInput uniqueId,
        [FromQuery()] WebhookWhereUniqueInput[] webhooksId
    )
    {
        try
        {
            await _service.ConnectWebhook(uniqueId, webhooksId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Api Key records from App Model
    /// </summary>
    [HttpDelete("{Id}/apiKeys")]
    public async Task<ActionResult> DisconnectApiKey(
        [FromRoute()] AppModelWhereUniqueInput uniqueId,
        [FromBody()] ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        try
        {
            await _service.DisconnectApiKey(uniqueId, apiKeysId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Credential records from App Model
    /// </summary>
    [HttpDelete("{Id}/credentials")]
    public async Task<ActionResult> DisconnectCredential(
        [FromRoute()] AppModelWhereUniqueInput uniqueId,
        [FromBody()] CredentialWhereUniqueInput[] credentialsId
    )
    {
        try
        {
            await _service.DisconnectCredential(uniqueId, credentialsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Webhook records from App Model
    /// </summary>
    [HttpDelete("{Id}/webhooks")]
    public async Task<ActionResult> DisconnectWebhook(
        [FromRoute()] AppModelWhereUniqueInput uniqueId,
        [FromBody()] WebhookWhereUniqueInput[] webhooksId
    )
    {
        try
        {
            await _service.DisconnectWebhook(uniqueId, webhooksId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Api Key records for App Model
    /// </summary>
    [HttpGet("{Id}/apiKeys")]
    public async Task<ActionResult<List<ApiKey>>> FindApiKey(
        [FromRoute()] AppModelWhereUniqueInput uniqueId,
        [FromQuery()] ApiKeyFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindApiKey(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Credential records for App Model
    /// </summary>
    [HttpGet("{Id}/credentials")]
    public async Task<ActionResult<List<Credential>>> FindCredential(
        [FromRoute()] AppModelWhereUniqueInput uniqueId,
        [FromQuery()] CredentialFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindCredential(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Webhook records for App Model
    /// </summary>
    [HttpGet("{Id}/webhooks")]
    public async Task<ActionResult<List<Webhook>>> FindWebhook(
        [FromRoute()] AppModelWhereUniqueInput uniqueId,
        [FromQuery()] WebhookFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindWebhook(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Meta data about App Model records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> AppModelsMeta(
        [FromQuery()] AppModelFindManyArgs filter
    )
    {
        return Ok(await _service.AppModelsMeta(filter));
    }

    /// <summary>
    /// Update multiple Api Key records for App Model
    /// </summary>
    [HttpPatch("{Id}/apiKeys")]
    public async Task<ActionResult> UpdateApiKey(
        [FromRoute()] AppModelWhereUniqueInput uniqueId,
        [FromBody()] ApiKeyWhereUniqueInput[] apiKeysId
    )
    {
        try
        {
            await _service.UpdateApiKey(uniqueId, apiKeysId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Credential records for App Model
    /// </summary>
    [HttpPatch("{Id}/credentials")]
    public async Task<ActionResult> UpdateCredential(
        [FromRoute()] AppModelWhereUniqueInput uniqueId,
        [FromBody()] CredentialWhereUniqueInput[] credentialsId
    )
    {
        try
        {
            await _service.UpdateCredential(uniqueId, credentialsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Webhook records for App Model
    /// </summary>
    [HttpPatch("{Id}/webhooks")]
    public async Task<ActionResult> UpdateWebhook(
        [FromRoute()] AppModelWhereUniqueInput uniqueId,
        [FromBody()] WebhookWhereUniqueInput[] webhooksId
    )
    {
        try
        {
            await _service.UpdateWebhook(uniqueId, webhooksId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Create one App Model
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<AppModel>> CreateAppModel(AppModelCreateInput input)
    {
        var appModel = await _service.CreateAppModel(input);

        return CreatedAtAction(nameof(AppModel), new { id = appModel.Id }, appModel);
    }

    /// <summary>
    /// Delete one App Model
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteAppModel([FromRoute()] AppModelWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteAppModel(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many AppModels
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<AppModel>>> AppModels(
        [FromQuery()] AppModelFindManyArgs filter
    )
    {
        return Ok(await _service.AppModels(filter));
    }

    /// <summary>
    /// Get one App Model
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<AppModel>> AppModel(
        [FromRoute()] AppModelWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.AppModel(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one App Model
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateAppModel(
        [FromRoute()] AppModelWhereUniqueInput uniqueId,
        [FromQuery()] AppModelUpdateInput appModelUpdateDto
    )
    {
        try
        {
            await _service.UpdateAppModel(uniqueId, appModelUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
