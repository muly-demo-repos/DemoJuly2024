using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class VerificationTokensControllerBase : ControllerBase
{
    protected readonly IVerificationTokensService _service;

    public VerificationTokensControllerBase(IVerificationTokensService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Verification Token
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<VerificationToken>> CreateVerificationToken(
        VerificationTokenCreateInput input
    )
    {
        var verificationToken = await _service.CreateVerificationToken(input);

        return CreatedAtAction(
            nameof(VerificationToken),
            new { id = verificationToken.Id },
            verificationToken
        );
    }

    /// <summary>
    /// Delete one Verification Token
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteVerificationToken(
        [FromRoute()] VerificationTokenWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteVerificationToken(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many VerificationTokens
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<VerificationToken>>> VerificationTokens(
        [FromQuery()] VerificationTokenFindManyArgs filter
    )
    {
        return Ok(await _service.VerificationTokens(filter));
    }

    /// <summary>
    /// Get one Verification Token
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<VerificationToken>> VerificationToken(
        [FromRoute()] VerificationTokenWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.VerificationToken(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Verification Token
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateVerificationToken(
        [FromRoute()] VerificationTokenWhereUniqueInput uniqueId,
        [FromQuery()] VerificationTokenUpdateInput verificationTokenUpdateDto
    )
    {
        try
        {
            await _service.UpdateVerificationToken(uniqueId, verificationTokenUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Meta data about Verification Token records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> VerificationTokensMeta(
        [FromQuery()] VerificationTokenFindManyArgs filter
    )
    {
        return Ok(await _service.VerificationTokensMeta(filter));
    }
}
