using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class HashedLinksControllerBase : ControllerBase
{
    protected readonly IHashedLinksService _service;

    public HashedLinksControllerBase(IHashedLinksService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Hashed Link
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<HashedLink>> CreateHashedLink(HashedLinkCreateInput input)
    {
        var hashedLink = await _service.CreateHashedLink(input);

        return CreatedAtAction(nameof(HashedLink), new { id = hashedLink.Id }, hashedLink);
    }

    /// <summary>
    /// Delete one Hashed Link
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteHashedLink(
        [FromRoute()] HashedLinkWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteHashedLink(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many HashedLinks
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<HashedLink>>> HashedLinks(
        [FromQuery()] HashedLinkFindManyArgs filter
    )
    {
        return Ok(await _service.HashedLinks(filter));
    }

    /// <summary>
    /// Get one Hashed Link
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<HashedLink>> HashedLink(
        [FromRoute()] HashedLinkWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.HashedLink(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a Event Type record for Hashed Link
    /// </summary>
    [HttpGet("{Id}/eventTypes")]
    public async Task<ActionResult<List<EventType>>> GetEventType(
        [FromRoute()] HashedLinkWhereUniqueInput uniqueId
    )
    {
        var eventType = await _service.GetEventType(uniqueId);
        return Ok(eventType);
    }

    /// <summary>
    /// Meta data about Hashed Link records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> HashedLinksMeta(
        [FromQuery()] HashedLinkFindManyArgs filter
    )
    {
        return Ok(await _service.HashedLinksMeta(filter));
    }

    /// <summary>
    /// Update one Hashed Link
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateHashedLink(
        [FromRoute()] HashedLinkWhereUniqueInput uniqueId,
        [FromQuery()] HashedLinkUpdateInput hashedLinkUpdateDto
    )
    {
        try
        {
            await _service.UpdateHashedLink(uniqueId, hashedLinkUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
