using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemoDotnet.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class WorkflowsControllerBase : ControllerBase
{
    protected readonly IWorkflowsService _service;

    public WorkflowsControllerBase(IWorkflowsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Workflow
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Workflow>> CreateWorkflow(WorkflowCreateInput input)
    {
        var workflow = await _service.CreateWorkflow(input);

        return CreatedAtAction(nameof(Workflow), new { id = workflow.Id }, workflow);
    }

    /// <summary>
    /// Delete one Workflow
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteWorkflow([FromRoute()] WorkflowWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteWorkflow(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Workflows
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Workflow>>> Workflows(
        [FromQuery()] WorkflowFindManyArgs filter
    )
    {
        return Ok(await _service.Workflows(filter));
    }

    /// <summary>
    /// Get one Workflow
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Workflow>> Workflow(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Workflow(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Workflow
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateWorkflow(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowUpdateInput workflowUpdateDto
    )
    {
        try
        {
            await _service.UpdateWorkflow(uniqueId, workflowUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Active On records to Workflow
    /// </summary>
    [HttpPost("{Id}/workflowsOnEventTypes")]
    public async Task<ActionResult> ConnectActiveOn(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        try
        {
            await _service.ConnectActiveOn(uniqueId, workflowsOnEventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Steps records to Workflow
    /// </summary>
    [HttpPost("{Id}/workflowSteps")]
    public async Task<ActionResult> ConnectSteps(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowStepWhereUniqueInput[] workflowStepsId
    )
    {
        try
        {
            await _service.ConnectSteps(uniqueId, workflowStepsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Active On records from Workflow
    /// </summary>
    [HttpDelete("{Id}/workflowsOnEventTypes")]
    public async Task<ActionResult> DisconnectActiveOn(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromBody()] WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        try
        {
            await _service.DisconnectActiveOn(uniqueId, workflowsOnEventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Steps records from Workflow
    /// </summary>
    [HttpDelete("{Id}/workflowSteps")]
    public async Task<ActionResult> DisconnectSteps(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromBody()] WorkflowStepWhereUniqueInput[] workflowStepsId
    )
    {
        try
        {
            await _service.DisconnectSteps(uniqueId, workflowStepsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Active On records for Workflow
    /// </summary>
    [HttpGet("{Id}/workflowsOnEventTypes")]
    public async Task<ActionResult<List<WorkflowsOnEventType>>> FindActiveOn(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowsOnEventTypeFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindActiveOn(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Steps records for Workflow
    /// </summary>
    [HttpGet("{Id}/workflowSteps")]
    public async Task<ActionResult<List<WorkflowStep>>> FindSteps(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowStepFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindSteps(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a User record for Workflow
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetUser(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Meta data about Workflow records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> WorkflowsMeta(
        [FromQuery()] WorkflowFindManyArgs filter
    )
    {
        return Ok(await _service.WorkflowsMeta(filter));
    }

    /// <summary>
    /// Update multiple Active On records for Workflow
    /// </summary>
    [HttpPatch("{Id}/workflowsOnEventTypes")]
    public async Task<ActionResult> UpdateActiveOn(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromBody()] WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        try
        {
            await _service.UpdateActiveOn(uniqueId, workflowsOnEventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Steps records for Workflow
    /// </summary>
    [HttpPatch("{Id}/workflowSteps")]
    public async Task<ActionResult> UpdateSteps(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromBody()] WorkflowStepWhereUniqueInput[] workflowStepsId
    )
    {
        try
        {
            await _service.UpdateSteps(uniqueId, workflowStepsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
