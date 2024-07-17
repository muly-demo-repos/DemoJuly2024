using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class WorkflowsOnEventTypesServiceBase : IWorkflowsOnEventTypesService
{
    protected readonly CactusDemoDbContext _context;

    public WorkflowsOnEventTypesServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Workflows On Event Type
    /// </summary>
    public async Task<WorkflowsOnEventType> CreateWorkflowsOnEventType(
        WorkflowsOnEventTypeCreateInput createDto
    )
    {
        var workflowsOnEventType = new WorkflowsOnEventTypeDbModel { };

        if (createDto.Id != null)
        {
            workflowsOnEventType.Id = createDto.Id.Value;
        }
        if (createDto.EventType != null)
        {
            workflowsOnEventType.EventType = await _context
                .EventTypes.Where(eventType => createDto.EventType.Id == eventType.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Workflow != null)
        {
            workflowsOnEventType.Workflow = await _context
                .Workflows.Where(workflow => createDto.Workflow.Id == workflow.Id)
                .FirstOrDefaultAsync();
        }

        _context.WorkflowsOnEventTypes.Add(workflowsOnEventType);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<WorkflowsOnEventTypeDbModel>(workflowsOnEventType.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Workflows On Event Type
    /// </summary>
    public async Task DeleteWorkflowsOnEventType(WorkflowsOnEventTypeWhereUniqueInput uniqueId)
    {
        var workflowsOnEventType = await _context.WorkflowsOnEventTypes.FindAsync(uniqueId.Id);
        if (workflowsOnEventType == null)
        {
            throw new NotFoundException();
        }

        _context.WorkflowsOnEventTypes.Remove(workflowsOnEventType);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many WorkflowsOnEventTypes
    /// </summary>
    public async Task<List<WorkflowsOnEventType>> WorkflowsOnEventTypes(
        WorkflowsOnEventTypeFindManyArgs findManyArgs
    )
    {
        var workflowsOnEventTypes = await _context
            .WorkflowsOnEventTypes.Include(x => x.EventType)
            .Include(x => x.Workflow)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return workflowsOnEventTypes.ConvertAll(workflowsOnEventType =>
            workflowsOnEventType.ToDto()
        );
    }

    /// <summary>
    /// Get one Workflows On Event Type
    /// </summary>
    public async Task<WorkflowsOnEventType> WorkflowsOnEventType(
        WorkflowsOnEventTypeWhereUniqueInput uniqueId
    )
    {
        var workflowsOnEventTypes = await this.WorkflowsOnEventTypes(
            new WorkflowsOnEventTypeFindManyArgs
            {
                Where = new WorkflowsOnEventTypeWhereInput { Id = uniqueId.Id }
            }
        );
        var workflowsOnEventType = workflowsOnEventTypes.FirstOrDefault();
        if (workflowsOnEventType == null)
        {
            throw new NotFoundException();
        }

        return workflowsOnEventType;
    }

    /// <summary>
    /// Update one Workflows On Event Type
    /// </summary>
    public async Task UpdateWorkflowsOnEventType(
        WorkflowsOnEventTypeWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeUpdateInput updateDto
    )
    {
        var workflowsOnEventType = updateDto.ToModel(uniqueId);

        _context.Entry(workflowsOnEventType).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.WorkflowsOnEventTypes.Any(e => e.Id == workflowsOnEventType.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Get a Event Type record for Workflows On Event Type
    /// </summary>
    public async Task<EventType> GetEventType(WorkflowsOnEventTypeWhereUniqueInput uniqueId)
    {
        var workflowsOnEventType = await _context
            .WorkflowsOnEventTypes.Where(workflowsOnEventType =>
                workflowsOnEventType.Id == uniqueId.Id
            )
            .Include(workflowsOnEventType => workflowsOnEventType.EventType)
            .FirstOrDefaultAsync();
        if (workflowsOnEventType == null)
        {
            throw new NotFoundException();
        }
        return workflowsOnEventType.EventType.ToDto();
    }

    /// <summary>
    /// Get a Workflow record for Workflows On Event Type
    /// </summary>
    public async Task<Workflow> GetWorkflow(WorkflowsOnEventTypeWhereUniqueInput uniqueId)
    {
        var workflowsOnEventType = await _context
            .WorkflowsOnEventTypes.Where(workflowsOnEventType =>
                workflowsOnEventType.Id == uniqueId.Id
            )
            .Include(workflowsOnEventType => workflowsOnEventType.Workflow)
            .FirstOrDefaultAsync();
        if (workflowsOnEventType == null)
        {
            throw new NotFoundException();
        }
        return workflowsOnEventType.Workflow.ToDto();
    }

    /// <summary>
    /// Meta data about Workflows On Event Type records
    /// </summary>
    public async Task<MetadataDto> WorkflowsOnEventTypesMeta(
        WorkflowsOnEventTypeFindManyArgs findManyArgs
    )
    {
        var count = await _context
            .WorkflowsOnEventTypes.ApplyWhere(findManyArgs.Where)
            .CountAsync();

        return new MetadataDto { Count = count };
    }
}
