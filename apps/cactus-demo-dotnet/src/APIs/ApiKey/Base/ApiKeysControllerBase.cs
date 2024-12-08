using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ApiKeysControllerBase : ControllerBase
{
    protected readonly IApiKeysService _service;

    public ApiKeysControllerBase(IApiKeysService service)
    {
        _service = service;
    }

    /// <summary>
    /// Get a App Field record for Api Key
    /// </summary>
    [HttpGet("{Id}/appModels")]
    public async Task<ActionResult<List<AppModel>>> GetAppField(
        [FromRoute()] ApiKeyWhereUniqueInput uniqueId
    )
    {
        var appModel = await _service.GetAppModel(uniqueId);
        return Ok(appModel);
    }

    /// <summary>
    /// Get a User record for Api Key
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] ApiKeyWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Meta data about Api Key records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ApiKeysMeta(
        [FromQuery()] ApiKeyFindManyArgs filter
    )
    {
        return Ok(await _service.ApiKeysMeta(filter));
    }

    /// <summary>
    /// Create one Api Key
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<ApiKey>> CreateApiKey(ApiKeyCreateInput input)
    {
        var apiKey = await _service.CreateApiKey(input);

        return CreatedAtAction(nameof(ApiKey), new { id = apiKey.Id }, apiKey);
    }

    /// <summary>
    /// Delete one Api Key
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteApiKey([FromRoute()] ApiKeyWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteApiKey(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ApiKeys
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<ApiKey>>> ApiKeys([FromQuery()] ApiKeyFindManyArgs filter)
    {
        return Ok(await _service.ApiKeys(filter));
    }

    /// <summary>
    /// Get one Api Key
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<ApiKey>> ApiKey([FromRoute()] ApiKeyWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.ApiKey(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Api Key
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateApiKey(
        [FromRoute()] ApiKeyWhereUniqueInput uniqueId,
        [FromQuery()] ApiKeyUpdateInput apiKeyUpdateDto
    )
    {
        try
        {
            await _service.UpdateApiKey(uniqueId, apiKeyUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
