using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class SessionsControllerBase : ControllerBase
{
    protected readonly ISessionsService _service;

    public SessionsControllerBase(ISessionsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Session
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Session>> CreateSession(SessionCreateInput input)
    {
        var session = await _service.CreateSession(input);

        return CreatedAtAction(nameof(Session), new { id = session.Id }, session);
    }

    /// <summary>
    /// Delete one Session
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteSession([FromRoute()] SessionWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteSession(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Sessions
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Session>>> Sessions(
        [FromQuery()] SessionFindManyArgs filter
    )
    {
        return Ok(await _service.Sessions(filter));
    }

    /// <summary>
    /// Get one Session
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Session>> Session([FromRoute()] SessionWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Session(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a User record for Session
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] SessionWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Meta data about Session records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> SessionsMeta(
        [FromQuery()] SessionFindManyArgs filter
    )
    {
        return Ok(await _service.SessionsMeta(filter));
    }

    /// <summary>
    /// Update one Session
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateSession(
        [FromRoute()] SessionWhereUniqueInput uniqueId,
        [FromQuery()] SessionUpdateInput sessionUpdateDto
    )
    {
        try
        {
            await _service.UpdateSession(uniqueId, sessionUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
