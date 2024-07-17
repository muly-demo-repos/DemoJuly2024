using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class WebhooksControllerBase : ControllerBase
{
    protected readonly IWebhooksService _service;

    public WebhooksControllerBase(IWebhooksService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Webhook
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Webhook>> CreateWebhook(WebhookCreateInput input)
    {
        var webhook = await _service.CreateWebhook(input);

        return CreatedAtAction(nameof(Webhook), new { id = webhook.Id }, webhook);
    }

    /// <summary>
    /// Delete one Webhook
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteWebhook([FromRoute()] WebhookWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteWebhook(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Webhooks
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Webhook>>> Webhooks(
        [FromQuery()] WebhookFindManyArgs filter
    )
    {
        return Ok(await _service.Webhooks(filter));
    }

    /// <summary>
    /// Get one Webhook
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Webhook>> Webhook([FromRoute()] WebhookWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Webhook(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Webhook
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateWebhook(
        [FromRoute()] WebhookWhereUniqueInput uniqueId,
        [FromQuery()] WebhookUpdateInput webhookUpdateDto
    )
    {
        try
        {
            await _service.UpdateWebhook(uniqueId, webhookUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a App Field record for Webhook
    /// </summary>
    [HttpGet("{Id}/appModels")]
    public async Task<ActionResult<List<AppModel>>> GetAppField(
        [FromRoute()] WebhookWhereUniqueInput uniqueId
    )
    {
        var appModel = await _service.GetAppModel(uniqueId);
        return Ok(appModel);
    }

    /// <summary>
    /// Get a Event Type record for Webhook
    /// </summary>
    [HttpGet("{Id}/eventTypes")]
    public async Task<ActionResult<List<EventType>>> GetEventType(
        [FromRoute()] WebhookWhereUniqueInput uniqueId
    )
    {
        var eventType = await _service.GetEventType(uniqueId);
        return Ok(eventType);
    }

    /// <summary>
    /// Get a User record for Webhook
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] WebhookWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Meta data about Webhook records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> WebhooksMeta(
        [FromQuery()] WebhookFindManyArgs filter
    )
    {
        return Ok(await _service.WebhooksMeta(filter));
    }
}
