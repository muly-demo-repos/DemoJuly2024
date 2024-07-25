using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class WorkflowStepsServiceBase : IWorkflowStepsService
{
    protected readonly CactusDemoDbContext _context;

    public WorkflowStepsServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Workflow Step
    /// </summary>
    public async Task<WorkflowStep> CreateWorkflowStep(WorkflowStepCreateInput createDto)
    {
        var workflowStep = new WorkflowStepDbModel
        {
            StepNumber = createDto.StepNumber,
            Action = createDto.Action,
            SendTo = createDto.SendTo,
            ReminderBody = createDto.ReminderBody,
            EmailSubject = createDto.EmailSubject,
            Template = createDto.Template
        };

        if (createDto.Id != null)
        {
            workflowStep.Id = createDto.Id.Value;
        }
        if (createDto.Workflow != null)
        {
            workflowStep.Workflow = await _context
                .Workflows.Where(workflow => createDto.Workflow.Id == workflow.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.WorkflowReminder != null)
        {
            workflowStep.WorkflowReminder = await _context
                .WorkflowReminders.Where(workflowReminder =>
                    createDto.WorkflowReminder.Select(t => t.Id).Contains(workflowReminder.Id)
                )
                .ToListAsync();
        }

        _context.WorkflowSteps.Add(workflowStep);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<WorkflowStepDbModel>(workflowStep.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Workflow Step
    /// </summary>
    public async Task DeleteWorkflowStep(WorkflowStepWhereUniqueInput uniqueId)
    {
        var workflowStep = await _context.WorkflowSteps.FindAsync(uniqueId.Id);
        if (workflowStep == null)
        {
            throw new NotFoundException();
        }

        _context.WorkflowSteps.Remove(workflowStep);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many WorkflowSteps
    /// </summary>
    public async Task<List<WorkflowStep>> WorkflowSteps(WorkflowStepFindManyArgs findManyArgs)
    {
        var workflowSteps = await _context
            .WorkflowSteps.Include(x => x.Workflow)
            .Include(x => x.WorkflowReminder)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return workflowSteps.ConvertAll(workflowStep => workflowStep.ToDto());
    }

    /// <summary>
    /// Get one Workflow Step
    /// </summary>
    public async Task<WorkflowStep> WorkflowStep(WorkflowStepWhereUniqueInput uniqueId)
    {
        var workflowSteps = await this.WorkflowSteps(
            new WorkflowStepFindManyArgs { Where = new WorkflowStepWhereInput { Id = uniqueId.Id } }
        );
        var workflowStep = workflowSteps.FirstOrDefault();
        if (workflowStep == null)
        {
            throw new NotFoundException();
        }

        return workflowStep;
    }

    /// <summary>
    /// Update one Workflow Step
    /// </summary>
    public async Task UpdateWorkflowStep(
        WorkflowStepWhereUniqueInput uniqueId,
        WorkflowStepUpdateInput updateDto
    )
    {
        var workflowStep = updateDto.ToModel(uniqueId);

        if (updateDto.WorkflowReminder != null)
        {
            workflowStep.WorkflowReminder = await _context
                .WorkflowReminders.Where(workflowReminder =>
                    updateDto.WorkflowReminder.Select(t => t).Contains(workflowReminder.Id)
                )
                .ToListAsync();
        }

        _context.Entry(workflowStep).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.WorkflowSteps.Any(e => e.Id == workflowStep.Id))
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
    /// Connect multiple Workflow Reminder records to Workflow Step
    /// </summary>
    public async Task ConnectWorkflowReminder(
        WorkflowStepWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        var workflowStep = await _context
            .WorkflowSteps.Include(x => x.WorkflowReminder)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (workflowStep == null)
        {
            throw new NotFoundException();
        }

        var workflowReminders = await _context
            .WorkflowReminders.Where(t => workflowRemindersId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (workflowReminders.Count == 0)
        {
            throw new NotFoundException();
        }

        var workflowRemindersToConnect = workflowReminders.Except(workflowStep.WorkflowReminder);

        foreach (var workflowReminder in workflowRemindersToConnect)
        {
            workflowStep.WorkflowReminder.Add(workflowReminder);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Workflow Reminder records from Workflow Step
    /// </summary>
    public async Task DisconnectWorkflowReminder(
        WorkflowStepWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        var workflowStep = await _context
            .WorkflowSteps.Include(x => x.WorkflowReminder)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (workflowStep == null)
        {
            throw new NotFoundException();
        }

        var workflowReminders = await _context
            .WorkflowReminders.Where(t => workflowRemindersId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var workflowReminder in workflowReminders)
        {
            workflowStep.WorkflowReminder?.Remove(workflowReminder);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Workflow Reminder records for Workflow Step
    /// </summary>
    public async Task<List<WorkflowReminder>> FindWorkflowReminder(
        WorkflowStepWhereUniqueInput uniqueId,
        WorkflowReminderFindManyArgs workflowStepFindManyArgs
    )
    {
        var workflowReminders = await _context
            .WorkflowReminders.Where(m => m.WorkflowStepId == uniqueId.Id)
            .ApplyWhere(workflowStepFindManyArgs.Where)
            .ApplySkip(workflowStepFindManyArgs.Skip)
            .ApplyTake(workflowStepFindManyArgs.Take)
            .ApplyOrderBy(workflowStepFindManyArgs.SortBy)
            .ToListAsync();

        return workflowReminders.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Get a Workflow record for Workflow Step
    /// </summary>
    public async Task<Workflow> GetWorkflow(WorkflowStepWhereUniqueInput uniqueId)
    {
        var workflowStep = await _context
            .WorkflowSteps.Where(workflowStep => workflowStep.Id == uniqueId.Id)
            .Include(workflowStep => workflowStep.Workflow)
            .FirstOrDefaultAsync();
        if (workflowStep == null)
        {
            throw new NotFoundException();
        }
        return workflowStep.Workflow.ToDto();
    }

    /// <summary>
    /// Meta data about Workflow Step records
    /// </summary>
    public async Task<MetadataDto> WorkflowStepsMeta(WorkflowStepFindManyArgs findManyArgs)
    {
        var count = await _context.WorkflowSteps.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update multiple Workflow Reminder records for Workflow Step
    /// </summary>
    public async Task UpdateWorkflowReminder(
        WorkflowStepWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        var workflowStep = await _context
            .WorkflowSteps.Include(t => t.WorkflowReminder)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (workflowStep == null)
        {
            throw new NotFoundException();
        }

        var workflowReminders = await _context
            .WorkflowReminders.Where(a => workflowRemindersId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (workflowReminders.Count == 0)
        {
            throw new NotFoundException();
        }

        workflowStep.WorkflowReminder = workflowReminders;
        await _context.SaveChangesAsync();
    }
}
