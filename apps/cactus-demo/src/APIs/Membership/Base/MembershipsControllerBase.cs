using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MembershipsControllerBase : ControllerBase
{
    protected readonly IMembershipsService _service;

    public MembershipsControllerBase(IMembershipsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Membership
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Membership>> CreateMembership(MembershipCreateInput input)
    {
        var membership = await _service.CreateMembership(input);

        return CreatedAtAction(nameof(Membership), new { id = membership.Id }, membership);
    }

    /// <summary>
    /// Delete one Membership
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteMembership(
        [FromRoute()] MembershipWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteMembership(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Memberships
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Membership>>> Memberships(
        [FromQuery()] MembershipFindManyArgs filter
    )
    {
        return Ok(await _service.Memberships(filter));
    }

    /// <summary>
    /// Get one Membership
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Membership>> Membership(
        [FromRoute()] MembershipWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Membership(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a Team record for Membership
    /// </summary>
    [HttpGet("{Id}/teams")]
    public async Task<ActionResult<List<Team>>> GetTeam(
        [FromRoute()] MembershipWhereUniqueInput uniqueId
    )
    {
        var team = await _service.GetTeam(uniqueId);
        return Ok(team);
    }

    /// <summary>
    /// Get a Users record for Membership
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetUsers(
        [FromRoute()] MembershipWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Meta data about Membership records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> MembershipsMeta(
        [FromQuery()] MembershipFindManyArgs filter
    )
    {
        return Ok(await _service.MembershipsMeta(filter));
    }

    /// <summary>
    /// Update one Membership
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateMembership(
        [FromRoute()] MembershipWhereUniqueInput uniqueId,
        [FromQuery()] MembershipUpdateInput membershipUpdateDto
    )
    {
        try
        {
            await _service.UpdateMembership(uniqueId, membershipUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
