using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace CactusDemo.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class FeedbacksControllerBase : ControllerBase
{
    protected readonly IFeedbacksService _service;

    public FeedbacksControllerBase(IFeedbacksService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Feedback
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Feedback>> CreateFeedback(FeedbackCreateInput input)
    {
        var feedback = await _service.CreateFeedback(input);

        return CreatedAtAction(nameof(Feedback), new { id = feedback.Id }, feedback);
    }

    /// <summary>
    /// Delete one Feedback
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteFeedback([FromRoute()] FeedbackWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteFeedback(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a Users record for Feedback
    /// </summary>
    [HttpGet("{Id}/users")]
    public async Task<ActionResult<List<User>>> GetUsers(
        [FromRoute()] FeedbackWhereUniqueInput uniqueId
    )
    {
        var user = await _service.GetUser(uniqueId);
        return Ok(user);
    }

    /// <summary>
    /// Meta data about Feedback records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> FeedbacksMeta(
        [FromQuery()] FeedbackFindManyArgs filter
    )
    {
        return Ok(await _service.FeedbacksMeta(filter));
    }

    /// <summary>
    /// Find many Feedbacks
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Feedback>>> Feedbacks(
        [FromQuery()] FeedbackFindManyArgs filter
    )
    {
        return Ok(await _service.Feedbacks(filter));
    }

    /// <summary>
    /// Get one Feedback
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Feedback>> Feedback(
        [FromRoute()] FeedbackWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.Feedback(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Feedback
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateFeedback(
        [FromRoute()] FeedbackWhereUniqueInput uniqueId,
        [FromQuery()] FeedbackUpdateInput feedbackUpdateDto
    )
    {
        try
        {
            await _service.UpdateFeedback(uniqueId, feedbackUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
