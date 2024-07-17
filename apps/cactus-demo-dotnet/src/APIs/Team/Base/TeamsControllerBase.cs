using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TeamsControllerBase : ControllerBase
{
    protected readonly ITeamsService _service;

    public TeamsControllerBase(ITeamsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Team
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Team>> CreateTeam(TeamCreateInput input)
    {
        var team = await _service.CreateTeam(input);

        return CreatedAtAction(nameof(Team), new { id = team.Id }, team);
    }

    /// <summary>
    /// Delete one Team
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteTeam([FromRoute()] TeamWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteTeam(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Teams
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Team>>> Teams([FromQuery()] TeamFindManyArgs filter)
    {
        return Ok(await _service.Teams(filter));
    }

    /// <summary>
    /// Get one Team
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Team>> Team([FromRoute()] TeamWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Team(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Connect multiple Event Types records to Team
    /// </summary>
    [HttpPost("{Id}/eventTypes")]
    public async Task<ActionResult> ConnectEventTypes(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromQuery()] EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        try
        {
            await _service.ConnectEventTypes(uniqueId, eventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Members records to Team
    /// </summary>
    [HttpPost("{Id}/memberships")]
    public async Task<ActionResult> ConnectMembers(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromQuery()] MembershipWhereUniqueInput[] membershipsId
    )
    {
        try
        {
            await _service.ConnectMembers(uniqueId, membershipsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Event Types records from Team
    /// </summary>
    [HttpDelete("{Id}/eventTypes")]
    public async Task<ActionResult> DisconnectEventTypes(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromBody()] EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        try
        {
            await _service.DisconnectEventTypes(uniqueId, eventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Members records from Team
    /// </summary>
    [HttpDelete("{Id}/memberships")]
    public async Task<ActionResult> DisconnectMembers(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromBody()] MembershipWhereUniqueInput[] membershipsId
    )
    {
        try
        {
            await _service.DisconnectMembers(uniqueId, membershipsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Event Types records for Team
    /// </summary>
    [HttpGet("{Id}/eventTypes")]
    public async Task<ActionResult<List<EventType>>> FindEventTypes(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromQuery()] EventTypeFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindEventTypes(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Members records for Team
    /// </summary>
    [HttpGet("{Id}/memberships")]
    public async Task<ActionResult<List<Membership>>> FindMembers(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromQuery()] MembershipFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindMembers(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Meta data about Team records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TeamsMeta([FromQuery()] TeamFindManyArgs filter)
    {
        return Ok(await _service.TeamsMeta(filter));
    }

    /// <summary>
    /// Update multiple Event Types records for Team
    /// </summary>
    [HttpPatch("{Id}/eventTypes")]
    public async Task<ActionResult> UpdateEventTypes(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromBody()] EventTypeWhereUniqueInput[] eventTypesId
    )
    {
        try
        {
            await _service.UpdateEventTypes(uniqueId, eventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Members records for Team
    /// </summary>
    [HttpPatch("{Id}/memberships")]
    public async Task<ActionResult> UpdateMembers(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromBody()] MembershipWhereUniqueInput[] membershipsId
    )
    {
        try
        {
            await _service.UpdateMembers(uniqueId, membershipsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update one Team
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateTeam(
        [FromRoute()] TeamWhereUniqueInput uniqueId,
        [FromQuery()] TeamUpdateInput teamUpdateDto
    )
    {
        try
        {
            await _service.UpdateTeam(uniqueId, teamUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
