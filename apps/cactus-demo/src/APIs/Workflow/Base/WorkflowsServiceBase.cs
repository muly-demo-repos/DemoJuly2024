using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class WorkflowsServiceBase : IWorkflowsService
{
    protected readonly CactusDemoDbContext _context;

    public WorkflowsServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Workflow
    /// </summary>
    public async Task<Workflow> CreateWorkflow(WorkflowCreateInput createDto)
    {
        var workflow = new WorkflowDbModel
        {
            Name = createDto.Name,
            Trigger = createDto.Trigger,
            Time = createDto.Time,
            TimeUnit = createDto.TimeUnit
        };

        if (createDto.Id != null)
        {
            workflow.Id = createDto.Id.Value;
        }
        if (createDto.WorkflowStep != null)
        {
            workflow.WorkflowStep = await _context
                .WorkflowSteps.Where(workflowStep =>
                    createDto.WorkflowStep.Select(t => t.Id).Contains(workflowStep.Id)
                )
                .ToListAsync();
        }

        if (createDto.WorkflowsOnEventTypes != null)
        {
            workflow.WorkflowsOnEventTypes = await _context
                .WorkflowsOnEventTypes.Where(workflowsOnEventType =>
                    createDto
                        .WorkflowsOnEventTypes.Select(t => t.Id)
                        .Contains(workflowsOnEventType.Id)
                )
                .ToListAsync();
        }

        if (createDto.Users != null)
        {
            workflow.Users = await _context
                .Users.Where(user => createDto.Users.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        _context.Workflows.Add(workflow);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<WorkflowDbModel>(workflow.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Workflow
    /// </summary>
    public async Task DeleteWorkflow(WorkflowWhereUniqueInput uniqueId)
    {
        var workflow = await _context.Workflows.FindAsync(uniqueId.Id);
        if (workflow == null)
        {
            throw new NotFoundException();
        }

        _context.Workflows.Remove(workflow);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Workflows
    /// </summary>
    public async Task<List<Workflow>> Workflows(WorkflowFindManyArgs findManyArgs)
    {
        var workflows = await _context
            .Workflows.Include(x => x.WorkflowStep)
            .Include(x => x.WorkflowsOnEventTypes)
            .Include(x => x.Users)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return workflows.ConvertAll(workflow => workflow.ToDto());
    }

    /// <summary>
    /// Get one Workflow
    /// </summary>
    public async Task<Workflow> Workflow(WorkflowWhereUniqueInput uniqueId)
    {
        var workflows = await this.Workflows(
            new WorkflowFindManyArgs { Where = new WorkflowWhereInput { Id = uniqueId.Id } }
        );
        var workflow = workflows.FirstOrDefault();
        if (workflow == null)
        {
            throw new NotFoundException();
        }

        return workflow;
    }

    /// <summary>
    /// Update one Workflow
    /// </summary>
    public async Task UpdateWorkflow(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowUpdateInput updateDto
    )
    {
        var workflow = updateDto.ToModel(uniqueId);

        if (updateDto.WorkflowStep != null)
        {
            workflow.WorkflowStep = await _context
                .WorkflowSteps.Where(workflowStep =>
                    updateDto.WorkflowStep.Select(t => t).Contains(workflowStep.Id)
                )
                .ToListAsync();
        }

        if (updateDto.WorkflowsOnEventTypes != null)
        {
            workflow.WorkflowsOnEventTypes = await _context
                .WorkflowsOnEventTypes.Where(workflowsOnEventType =>
                    updateDto.WorkflowsOnEventTypes.Select(t => t).Contains(workflowsOnEventType.Id)
                )
                .ToListAsync();
        }

        _context.Entry(workflow).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Workflows.Any(e => e.Id == workflow.Id))
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
    /// Connect multiple Workflows On Event Types records to Workflow
    /// </summary>
    public async Task ConnectWorkflowsOnEventTypes(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        var workflow = await _context
            .Workflows.Include(x => x.WorkflowsOnEventTypes)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (workflow == null)
        {
            throw new NotFoundException();
        }

        var workflowsOnEventTypes = await _context
            .WorkflowsOnEventTypes.Where(t =>
                workflowsOnEventTypesId.Select(x => x.Id).Contains(t.Id)
            )
            .ToListAsync();
        if (workflowsOnEventTypes.Count == 0)
        {
            throw new NotFoundException();
        }

        var workflowsOnEventTypesToConnect = workflowsOnEventTypes.Except(
            workflow.WorkflowsOnEventTypes
        );

        foreach (var workflowsOnEventType in workflowsOnEventTypesToConnect)
        {
            workflow.WorkflowsOnEventTypes.Add(workflowsOnEventType);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Workflow Step records to Workflow
    /// </summary>
    public async Task ConnectWorkflowStep(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowStepWhereUniqueInput[] workflowStepsId
    )
    {
        var workflow = await _context
            .Workflows.Include(x => x.WorkflowStep)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (workflow == null)
        {
            throw new NotFoundException();
        }

        var workflowSteps = await _context
            .WorkflowSteps.Where(t => workflowStepsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (workflowSteps.Count == 0)
        {
            throw new NotFoundException();
        }

        var workflowStepsToConnect = workflowSteps.Except(workflow.WorkflowStep);

        foreach (var workflowStep in workflowStepsToConnect)
        {
            workflow.WorkflowStep.Add(workflowStep);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Workflows On Event Types records from Workflow
    /// </summary>
    public async Task DisconnectWorkflowsOnEventTypes(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        var workflow = await _context
            .Workflows.Include(x => x.WorkflowsOnEventTypes)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (workflow == null)
        {
            throw new NotFoundException();
        }

        var workflowsOnEventTypes = await _context
            .WorkflowsOnEventTypes.Where(t =>
                workflowsOnEventTypesId.Select(x => x.Id).Contains(t.Id)
            )
            .ToListAsync();

        foreach (var workflowsOnEventType in workflowsOnEventTypes)
        {
            workflow.WorkflowsOnEventTypes?.Remove(workflowsOnEventType);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Workflow Step records from Workflow
    /// </summary>
    public async Task DisconnectWorkflowStep(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowStepWhereUniqueInput[] workflowStepsId
    )
    {
        var workflow = await _context
            .Workflows.Include(x => x.WorkflowStep)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (workflow == null)
        {
            throw new NotFoundException();
        }

        var workflowSteps = await _context
            .WorkflowSteps.Where(t => workflowStepsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var workflowStep in workflowSteps)
        {
            workflow.WorkflowStep?.Remove(workflowStep);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Workflows On Event Types records for Workflow
    /// </summary>
    public async Task<List<WorkflowsOnEventType>> FindWorkflowsOnEventTypes(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeFindManyArgs workflowFindManyArgs
    )
    {
        var workflowsOnEventTypes = await _context
            .WorkflowsOnEventTypes.Where(m => m.WorkflowId == uniqueId.Id)
            .ApplyWhere(workflowFindManyArgs.Where)
            .ApplySkip(workflowFindManyArgs.Skip)
            .ApplyTake(workflowFindManyArgs.Take)
            .ApplyOrderBy(workflowFindManyArgs.SortBy)
            .ToListAsync();

        return workflowsOnEventTypes.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Workflow Step records for Workflow
    /// </summary>
    public async Task<List<WorkflowStep>> FindWorkflowStep(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowStepFindManyArgs workflowFindManyArgs
    )
    {
        var workflowSteps = await _context
            .WorkflowSteps.Where(m => m.WorkflowId == uniqueId.Id)
            .ApplyWhere(workflowFindManyArgs.Where)
            .ApplySkip(workflowFindManyArgs.Skip)
            .ApplyTake(workflowFindManyArgs.Take)
            .ApplyOrderBy(workflowFindManyArgs.SortBy)
            .ToListAsync();

        return workflowSteps.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Get a Users record for Workflow
    /// </summary>
    public async Task<User> GetUsers(WorkflowWhereUniqueInput uniqueId)
    {
        var workflow = await _context
            .Workflows.Where(workflow => workflow.Id == uniqueId.Id)
            .Include(workflow => workflow.Users)
            .FirstOrDefaultAsync();
        if (workflow == null)
        {
            throw new NotFoundException();
        }
        return workflow.Users.ToDto();
    }

    /// <summary>
    /// Meta data about Workflow records
    /// </summary>
    public async Task<MetadataDto> WorkflowsMeta(WorkflowFindManyArgs findManyArgs)
    {
        var count = await _context.Workflows.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update multiple Workflows On Event Types records for Workflow
    /// </summary>
    public async Task UpdateWorkflowsOnEventTypes(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        var workflow = await _context
            .Workflows.Include(t => t.WorkflowsOnEventTypes)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (workflow == null)
        {
            throw new NotFoundException();
        }

        var workflowsOnEventTypes = await _context
            .WorkflowsOnEventTypes.Where(a =>
                workflowsOnEventTypesId.Select(x => x.Id).Contains(a.Id)
            )
            .ToListAsync();

        if (workflowsOnEventTypes.Count == 0)
        {
            throw new NotFoundException();
        }

        workflow.WorkflowsOnEventTypes = workflowsOnEventTypes;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Workflow Step records for Workflow
    /// </summary>
    public async Task UpdateWorkflowStep(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowStepWhereUniqueInput[] workflowStepsId
    )
    {
        var workflow = await _context
            .Workflows.Include(t => t.WorkflowStep)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (workflow == null)
        {
            throw new NotFoundException();
        }

        var workflowSteps = await _context
            .WorkflowSteps.Where(a => workflowStepsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (workflowSteps.Count == 0)
        {
            throw new NotFoundException();
        }

        workflow.WorkflowStep = workflowSteps;
        await _context.SaveChangesAsync();
    }
}
