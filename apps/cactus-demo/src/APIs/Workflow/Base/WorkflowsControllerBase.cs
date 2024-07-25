using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

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
    /// Connect multiple Workflows On Event Types records to Workflow
    /// </summary>
    [HttpPost("{Id}/workflowsOnEventTypes")]
    public async Task<ActionResult> ConnectWorkflowsOnEventTypes(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        try
        {
            await _service.ConnectWorkflowsOnEventTypes(uniqueId, workflowsOnEventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple Workflow Step records to Workflow
    /// </summary>
    [HttpPost("{Id}/workflowSteps")]
    public async Task<ActionResult> ConnectWorkflowStep(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowStepWhereUniqueInput[] workflowStepsId
    )
    {
        try
        {
            await _service.ConnectWorkflowStep(uniqueId, workflowStepsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Workflows On Event Types records from Workflow
    /// </summary>
    [HttpDelete("{Id}/workflowsOnEventTypes")]
    public async Task<ActionResult> DisconnectWorkflowsOnEventTypes(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromBody()] WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        try
        {
            await _service.DisconnectWorkflowsOnEventTypes(uniqueId, workflowsOnEventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple Workflow Step records from Workflow
    /// </summary>
    [HttpDelete("{Id}/workflowSteps")]
    public async Task<ActionResult> DisconnectWorkflowStep(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromBody()] WorkflowStepWhereUniqueInput[] workflowStepsId
    )
    {
        try
        {
            await _service.DisconnectWorkflowStep(uniqueId, workflowStepsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple Workflows On Event Types records for Workflow
    /// </summary>
    [HttpGet("{Id}/workflowsOnEventTypes")]
    public async Task<ActionResult<List<WorkflowsOnEventType>>> FindWorkflowsOnEventTypes(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowsOnEventTypeFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindWorkflowsOnEventTypes(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Find multiple Workflow Step records for Workflow
    /// </summary>
    [HttpGet("{Id}/workflowSteps")]
    public async Task<ActionResult<List<WorkflowStep>>> FindWorkflowStep(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromQuery()] WorkflowStepFindManyArgs filter
    )
    {
        try
        {
            return Ok(await _service.FindWorkflowStep(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Get a Users record for Workflow
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetUsers(
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
    /// Update multiple Workflows On Event Types records for Workflow
    /// </summary>
    [HttpPatch("{Id}/workflowsOnEventTypes")]
    public async Task<ActionResult> UpdateWorkflowsOnEventTypes(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromBody()] WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        try
        {
            await _service.UpdateWorkflowsOnEventTypes(uniqueId, workflowsOnEventTypesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Update multiple Workflow Step records for Workflow
    /// </summary>
    [HttpPatch("{Id}/workflowSteps")]
    public async Task<ActionResult> UpdateWorkflowStep(
        [FromRoute()] WorkflowWhereUniqueInput uniqueId,
        [FromBody()] WorkflowStepWhereUniqueInput[] workflowStepsId
    )
    {
        try
        {
            await _service.UpdateWorkflowStep(uniqueId, workflowStepsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
