using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ImpersonationsControllerBase : ControllerBase
{
    protected readonly IImpersonationsService _service;

    public ImpersonationsControllerBase(IImpersonationsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Impersonation
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Impersonation>> CreateImpersonation(
        ImpersonationCreateInput input
    )
    {
        var impersonation = await _service.CreateImpersonation(input);

        return CreatedAtAction(nameof(Impersonation), new { id = impersonation.Id }, impersonation);
    }

    /// <summary>
    /// Delete one Impersonation
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteImpersonation(
        [FromRoute()] ImpersonationWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteImpersonation(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Impersonations
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Impersonation>>> Impersonations(
        [FromQuery()] ImpersonationFindManyArgs filter
    )
    {
        return Ok(await _service.Impersonations(filter));
    }

    /// <summary>
    /// Get one Impersonation
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Impersonation>> Impersonation(
        [FromRoute()] ImpersonationWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Impersonation(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a Impersonated By record for Impersonation
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetImpersonatedBy(
        [FromRoute()] ImpersonationWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Get a Impersonated User record for Impersonation
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetImpersonatedUser(
        [FromRoute()] ImpersonationWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Meta data about Impersonation records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ImpersonationsMeta(
        [FromQuery()] ImpersonationFindManyArgs filter
    )
    {
        return Ok(await _service.ImpersonationsMeta(filter));
    }

    /// <summary>
    /// Update one Impersonation
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateImpersonation(
        [FromRoute()] ImpersonationWhereUniqueInput uniqueId,
        [FromQuery()] ImpersonationUpdateInput impersonationUpdateDto
    )
    {
        try
        {
            await _service.UpdateImpersonation(uniqueId, impersonationUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
