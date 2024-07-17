using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using CactusDemoDotnet.APIs.Extensions;
using CactusDemoDotnet.Infrastructure;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemoDotnet.APIs;

public abstract class WorkflowsServiceBase : IWorkflowsService
{
    protected readonly CactusDemoDotnetDbContext _context;

    public WorkflowsServiceBase(CactusDemoDotnetDbContext context)
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
        if (createDto.User != null)
        {
            workflow.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Steps != null)
        {
            workflow.Steps = await _context
                .WorkflowSteps.Where(workflowStep =>
                    createDto.Steps.Select(t => t.Id).Contains(workflowStep.Id)
                )
                .ToListAsync();
        }

        if (createDto.ActiveOn != null)
        {
            workflow.ActiveOn = await _context
                .WorkflowsOnEventTypes.Where(workflowsOnEventType =>
                    createDto.ActiveOn.Select(t => t.Id).Contains(workflowsOnEventType.Id)
                )
                .ToListAsync();
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
            .Workflows.Include(x => x.User)
            .Include(x => x.Steps)
            .Include(x => x.ActiveOn)
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

        if (updateDto.Steps != null)
        {
            workflow.Steps = await _context
                .WorkflowSteps.Where(workflowStep =>
                    updateDto.Steps.Select(t => t).Contains(workflowStep.Id)
                )
                .ToListAsync();
        }

        if (updateDto.ActiveOn != null)
        {
            workflow.ActiveOn = await _context
                .WorkflowsOnEventTypes.Where(workflowsOnEventType =>
                    updateDto.ActiveOn.Select(t => t).Contains(workflowsOnEventType.Id)
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
    /// Connect multiple Active On records to Workflow
    /// </summary>
    public async Task ConnectActiveOn(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        var workflow = await _context
            .Workflows.Include(x => x.ActiveOn)
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

        var workflowsOnEventTypesToConnect = workflowsOnEventTypes.Except(workflow.ActiveOn);

        foreach (var workflowsOnEventType in workflowsOnEventTypesToConnect)
        {
            workflow.ActiveOn.Add(workflowsOnEventType);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Steps records to Workflow
    /// </summary>
    public async Task ConnectSteps(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowStepWhereUniqueInput[] workflowStepsId
    )
    {
        var workflow = await _context
            .Workflows.Include(x => x.Steps)
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

        var workflowStepsToConnect = workflowSteps.Except(workflow.Steps);

        foreach (var workflowStep in workflowStepsToConnect)
        {
            workflow.Steps.Add(workflowStep);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Active On records from Workflow
    /// </summary>
    public async Task DisconnectActiveOn(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        var workflow = await _context
            .Workflows.Include(x => x.ActiveOn)
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
            workflow.ActiveOn?.Remove(workflowsOnEventType);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Steps records from Workflow
    /// </summary>
    public async Task DisconnectSteps(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowStepWhereUniqueInput[] workflowStepsId
    )
    {
        var workflow = await _context
            .Workflows.Include(x => x.Steps)
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
            workflow.Steps?.Remove(workflowStep);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Active On records for Workflow
    /// </summary>
    public async Task<List<WorkflowsOnEventType>> FindActiveOn(
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
    /// Find multiple Steps records for Workflow
    /// </summary>
    public async Task<List<WorkflowStep>> FindSteps(
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
    /// Get a User record for Workflow
    /// </summary>
    public async Task<User> GetUser(WorkflowWhereUniqueInput uniqueId)
    {
        var workflow = await _context
            .Workflows.Where(workflow => workflow.Id == uniqueId.Id)
            .Include(workflow => workflow.User)
            .FirstOrDefaultAsync();
        if (workflow == null)
        {
            throw new NotFoundException();
        }
        return workflow.User.ToDto();
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
    /// Update multiple Active On records for Workflow
    /// </summary>
    public async Task UpdateActiveOn(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowsOnEventTypeWhereUniqueInput[] workflowsOnEventTypesId
    )
    {
        var workflow = await _context
            .Workflows.Include(t => t.ActiveOn)
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

        workflow.ActiveOn = workflowsOnEventTypes;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Steps records for Workflow
    /// </summary>
    public async Task UpdateSteps(
        WorkflowWhereUniqueInput uniqueId,
        WorkflowStepWhereUniqueInput[] workflowStepsId
    )
    {
        var workflow = await _context
            .Workflows.Include(t => t.Steps)
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

        workflow.Steps = workflowSteps;
        await _context.SaveChangesAsync();
    }
}
