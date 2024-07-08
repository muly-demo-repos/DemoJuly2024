using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QaService.APIs;
using QaService.APIs.Common;
using QaService.APIs.Dtos;
using QaService.APIs.Errors;

namespace QaService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class ProcessingAuditsControllerBase : ControllerBase
{
    protected readonly IProcessingAuditsService _service;

    public ProcessingAuditsControllerBase(IProcessingAuditsService service)
    {
        _service = service;
    }

    [HttpGet("{Id}/calculate-something")]
    [Authorize(Roles = "admin,user")]
    public async Task<double> CalculateSomething([FromBody()] string data)
    {
        return await _service.CalculateSomething(data);
    }

    /// <summary>
    /// Create one ProcessingAudit
    /// </summary>
    [HttpPost()]
    [Authorize(Roles = "admin,user")]
    public async Task<ActionResult<ProcessingAudit>> CreateProcessingAudit(
        ProcessingAuditCreateInput input
    )
    {
        var processingAudit = await _service.CreateProcessingAudit(input);

        return CreatedAtAction(
            nameof(ProcessingAudit),
            new { id = processingAudit.Id },
            processingAudit
        );
    }

    /// <summary>
    /// Delete one ProcessingAudit
    /// </summary>
    [HttpDelete("{Id}")]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult> DeleteProcessingAudit(
        [FromRoute()] ProcessingAuditWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteProcessingAudit(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many ProcessingAudits
    /// </summary>
    [HttpGet()]
    [Authorize(Roles = "admin,user")]
    public async Task<ActionResult<List<ProcessingAudit>>> ProcessingAudits(
        [FromQuery()] ProcessingAuditFindManyArgs filter
    )
    {
        return Ok(await _service.ProcessingAudits(filter));
    }

    /// <summary>
    /// Get one ProcessingAudit
    /// </summary>
    [HttpGet("{Id}")]
    [Authorize(Roles = "admin,user")]
    public async Task<ActionResult<ProcessingAudit>> ProcessingAudit(
        [FromRoute()] ProcessingAuditWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.ProcessingAudit(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Meta data about ProcessingAudit records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> ProcessingAuditsMeta(
        [FromQuery()] ProcessingAuditFindManyArgs filter
    )
    {
        return Ok(await _service.ProcessingAuditsMeta(filter));
    }

    /// <summary>
    /// Update one ProcessingAudit
    /// </summary>
    [HttpPatch("{Id}")]
    [Authorize(Roles = "admin,user")]
    public async Task<ActionResult> UpdateProcessingAudit(
        [FromRoute()] ProcessingAuditWhereUniqueInput uniqueId,
        [FromQuery()] ProcessingAuditUpdateInput processingAuditUpdateDto
    )
    {
        try
        {
            await _service.UpdateProcessingAudit(uniqueId, processingAuditUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
