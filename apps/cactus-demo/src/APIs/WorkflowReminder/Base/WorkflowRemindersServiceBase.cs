using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class WorkflowRemindersServiceBase : IWorkflowRemindersService
{
    protected readonly CactusDemoDbContext _context;

    public WorkflowRemindersServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Workflow Reminder
    /// </summary>
    public async Task<WorkflowReminder> CreateWorkflowReminder(
        WorkflowReminderCreateInput createDto
    )
    {
        var workflowReminder = new WorkflowReminderDbModel
        {
            Method = createDto.Method,
            ScheduledDate = createDto.ScheduledDate,
            ReferenceId = createDto.ReferenceId,
            Scheduled = createDto.Scheduled
        };

        if (createDto.Id != null)
        {
            workflowReminder.Id = createDto.Id.Value;
        }
        if (createDto.Booking != null)
        {
            workflowReminder.Booking = await _context
                .Bookings.Where(booking => createDto.Booking.Id == booking.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.WorkflowStep != null)
        {
            workflowReminder.WorkflowStep = await _context
                .WorkflowSteps.Where(workflowStep => createDto.WorkflowStep.Id == workflowStep.Id)
                .FirstOrDefaultAsync();
        }

        _context.WorkflowReminders.Add(workflowReminder);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<WorkflowReminderDbModel>(workflowReminder.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Workflow Reminder
    /// </summary>
    public async Task DeleteWorkflowReminder(WorkflowReminderWhereUniqueInput uniqueId)
    {
        var workflowReminder = await _context.WorkflowReminders.FindAsync(uniqueId.Id);
        if (workflowReminder == null)
        {
            throw new NotFoundException();
        }

        _context.WorkflowReminders.Remove(workflowReminder);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many WorkflowReminders
    /// </summary>
    public async Task<List<WorkflowReminder>> WorkflowReminders(
        WorkflowReminderFindManyArgs findManyArgs
    )
    {
        var workflowReminders = await _context
            .WorkflowReminders.Include(x => x.Booking)
            .Include(x => x.WorkflowStep)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return workflowReminders.ConvertAll(workflowReminder => workflowReminder.ToDto());
    }

    /// <summary>
    /// Get one Workflow Reminder
    /// </summary>
    public async Task<WorkflowReminder> WorkflowReminder(WorkflowReminderWhereUniqueInput uniqueId)
    {
        var workflowReminders = await this.WorkflowReminders(
            new WorkflowReminderFindManyArgs
            {
                Where = new WorkflowReminderWhereInput { Id = uniqueId.Id }
            }
        );
        var workflowReminder = workflowReminders.FirstOrDefault();
        if (workflowReminder == null)
        {
            throw new NotFoundException();
        }

        return workflowReminder;
    }

    /// <summary>
    /// Update one Workflow Reminder
    /// </summary>
    public async Task UpdateWorkflowReminder(
        WorkflowReminderWhereUniqueInput uniqueId,
        WorkflowReminderUpdateInput updateDto
    )
    {
        var workflowReminder = updateDto.ToModel(uniqueId);

        _context.Entry(workflowReminder).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.WorkflowReminders.Any(e => e.Id == workflowReminder.Id))
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
    /// Get a Booking record for Workflow Reminder
    /// </summary>
    public async Task<Booking> GetBooking(WorkflowReminderWhereUniqueInput uniqueId)
    {
        var workflowReminder = await _context
            .WorkflowReminders.Where(workflowReminder => workflowReminder.Id == uniqueId.Id)
            .Include(workflowReminder => workflowReminder.Booking)
            .FirstOrDefaultAsync();
        if (workflowReminder == null)
        {
            throw new NotFoundException();
        }
        return workflowReminder.Booking.ToDto();
    }

    /// <summary>
    /// Get a Workflow Step record for Workflow Reminder
    /// </summary>
    public async Task<WorkflowStep> GetWorkflowStep(WorkflowReminderWhereUniqueInput uniqueId)
    {
        var workflowReminder = await _context
            .WorkflowReminders.Where(workflowReminder => workflowReminder.Id == uniqueId.Id)
            .Include(workflowReminder => workflowReminder.WorkflowStep)
            .FirstOrDefaultAsync();
        if (workflowReminder == null)
        {
            throw new NotFoundException();
        }
        return workflowReminder.WorkflowStep.ToDto();
    }

    /// <summary>
    /// Meta data about Workflow Reminder records
    /// </summary>
    public async Task<MetadataDto> WorkflowRemindersMeta(WorkflowReminderFindManyArgs findManyArgs)
    {
        var count = await _context.WorkflowReminders.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }
}
