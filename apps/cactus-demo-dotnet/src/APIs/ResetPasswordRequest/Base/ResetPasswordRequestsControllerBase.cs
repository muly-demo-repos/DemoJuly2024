using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ResetPasswordRequestsControllerBase : ControllerBase
{
    protected readonly IResetPasswordRequestsService _service;

    public ResetPasswordRequestsControllerBase(IResetPasswordRequestsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Reset Password Request
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<ResetPasswordRequest>> CreateResetPasswordRequest(
        ResetPasswordRequestCreateInput input
    )
    {
        var resetPasswordRequest = await _service.CreateResetPasswordRequest(input);

        return CreatedAtAction(
            nameof(ResetPasswordRequest),
            new { id = resetPasswordRequest.Id },
            resetPasswordRequest
        );
    }

    /// <summary>
    /// Delete one Reset Password Request
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteResetPasswordRequest(
        [FromRoute()] ResetPasswordRequestWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteResetPasswordRequest(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ResetPasswordRequests
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<ResetPasswordRequest>>> ResetPasswordRequests(
        [FromQuery()] ResetPasswordRequestFindManyArgs filter
    )
    {
        return Ok(await _service.ResetPasswordRequests(filter));
    }

    /// <summary>
    /// Get one Reset Password Request
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<ResetPasswordRequest>> ResetPasswordRequest(
        [FromRoute()] ResetPasswordRequestWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ResetPasswordRequest(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Meta data about Reset Password Request records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ResetPasswordRequestsMeta(
        [FromQuery()] ResetPasswordRequestFindManyArgs filter
    )
    {
        return Ok(await _service.ResetPasswordRequestsMeta(filter));
    }

    /// <summary>
    /// Update one Reset Password Request
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateResetPasswordRequest(
        [FromRoute()] ResetPasswordRequestWhereUniqueInput uniqueId,
        [FromQuery()] ResetPasswordRequestUpdateInput resetPasswordRequestUpdateDto
    )
    {
        try
        {
            await _service.UpdateResetPasswordRequest(uniqueId, resetPasswordRequestUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
