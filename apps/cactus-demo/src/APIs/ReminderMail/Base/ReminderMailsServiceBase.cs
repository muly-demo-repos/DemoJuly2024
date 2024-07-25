using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class ReminderMailsServiceBase : IReminderMailsService
{
    protected readonly CactusDemoDbContext _context;

    public ReminderMailsServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Reminder Mail
    /// </summary>
    public async Task<ReminderMail> CreateReminderMail(ReminderMailCreateInput createDto)
    {
        var reminderMail = new ReminderMailDbModel
        {
            ReferenceId = createDto.ReferenceId,
            ReminderType = createDto.ReminderType,
            ElapsedMinutes = createDto.ElapsedMinutes,
            CreatedAt = createDto.CreatedAt
        };

        if (createDto.Id != null)
        {
            reminderMail.Id = createDto.Id.Value;
        }

        _context.ReminderMails.Add(reminderMail);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ReminderMailDbModel>(reminderMail.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Reminder Mail
    /// </summary>
    public async Task DeleteReminderMail(ReminderMailWhereUniqueInput uniqueId)
    {
        var reminderMail = await _context.ReminderMails.FindAsync(uniqueId.Id);
        if (reminderMail == null)
        {
            throw new NotFoundException();
        }

        _context.ReminderMails.Remove(reminderMail);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ReminderMails
    /// </summary>
    public async Task<List<ReminderMail>> ReminderMails(ReminderMailFindManyArgs findManyArgs)
    {
        var reminderMails = await _context
            .ReminderMails.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return reminderMails.ConvertAll(reminderMail => reminderMail.ToDto());
    }

    /// <summary>
    /// Get one Reminder Mail
    /// </summary>
    public async Task<ReminderMail> ReminderMail(ReminderMailWhereUniqueInput uniqueId)
    {
        var reminderMails = await this.ReminderMails(
            new ReminderMailFindManyArgs { Where = new ReminderMailWhereInput { Id = uniqueId.Id } }
        );
        var reminderMail = reminderMails.FirstOrDefault();
        if (reminderMail == null)
        {
            throw new NotFoundException();
        }

        return reminderMail;
    }

    /// <summary>
    /// Meta data about Reminder Mail records
    /// </summary>
    public async Task<MetadataDto> ReminderMailsMeta(ReminderMailFindManyArgs findManyArgs)
    {
        var count = await _context.ReminderMails.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update one Reminder Mail
    /// </summary>
    public async Task UpdateReminderMail(
        ReminderMailWhereUniqueInput uniqueId,
        ReminderMailUpdateInput updateDto
    )
    {
        var reminderMail = updateDto.ToModel(uniqueId);

        _context.Entry(reminderMail).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ReminderMails.Any(e => e.Id == reminderMail.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
