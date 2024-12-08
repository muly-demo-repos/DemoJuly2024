using CactusDemoDotnet.APIs;
using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.APIs.Errors;
using CactusDemoDotnet.APIs.Extensions;
using CactusDemoDotnet.Infrastructure;
using CactusDemoDotnet.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemoDotnet.APIs;

public abstract class BookingsServiceBase : IBookingsService
{
    protected readonly CactusDemoDotnetDbContext _context;

    public BookingsServiceBase(CactusDemoDotnetDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Connect multiple Attendees records to Booking
    /// </summary>
    public async Task ConnectAttendees(
        BookingWhereUniqueInput uniqueId,
        AttendeeWhereUniqueInput[] attendeesId
    )
    {
        var booking = await _context
            .Bookings.Include(x => x.Attendees)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (booking == null)
        {
            throw new NotFoundException();
        }

        var attendees = await _context
            .Attendees.Where(t => attendeesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (attendees.Count == 0)
        {
            throw new NotFoundException();
        }

        var attendeesToConnect = attendees.Except(booking.Attendees);

        foreach (var attendee in attendeesToConnect)
        {
            booking.Attendees.Add(attendee);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Payment records to Booking
    /// </summary>
    public async Task ConnectPayment(
        BookingWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    )
    {
        var booking = await _context
            .Bookings.Include(x => x.Payment)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (booking == null)
        {
            throw new NotFoundException();
        }

        var payments = await _context
            .Payments.Where(t => paymentsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (payments.Count == 0)
        {
            throw new NotFoundException();
        }

        var paymentsToConnect = payments.Except(booking.Payment);

        foreach (var payment in paymentsToConnect)
        {
            booking.Payment.Add(payment);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple References records to Booking
    /// </summary>
    public async Task ConnectReferences(
        BookingWhereUniqueInput uniqueId,
        BookingReferenceWhereUniqueInput[] bookingReferencesId
    )
    {
        var booking = await _context
            .Bookings.Include(x => x.References)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (booking == null)
        {
            throw new NotFoundException();
        }

        var bookingReferences = await _context
            .BookingReferences.Where(t => bookingReferencesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();
        if (bookingReferences.Count == 0)
        {
            throw new NotFoundException();
        }

        var bookingReferencesToConnect = bookingReferences.Except(booking.References);

        foreach (var bookingReference in bookingReferencesToConnect)
        {
            booking.References.Add(bookingReference);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Workflow Reminders records to Booking
    /// </summary>
    public async Task ConnectWorkflowReminders(
        BookingWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        var booking = await _context
            .Bookings.Include(x => x.WorkflowReminders)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (booking == null)
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

        var workflowRemindersToConnect = workflowReminders.Except(booking.WorkflowReminders);

        foreach (var workflowReminder in workflowRemindersToConnect)
        {
            booking.WorkflowReminders.Add(workflowReminder);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Attendees records from Booking
    /// </summary>
    public async Task DisconnectAttendees(
        BookingWhereUniqueInput uniqueId,
        AttendeeWhereUniqueInput[] attendeesId
    )
    {
        var booking = await _context
            .Bookings.Include(x => x.Attendees)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (booking == null)
        {
            throw new NotFoundException();
        }

        var attendees = await _context
            .Attendees.Where(t => attendeesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var attendee in attendees)
        {
            booking.Attendees?.Remove(attendee);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Payment records from Booking
    /// </summary>
    public async Task DisconnectPayment(
        BookingWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    )
    {
        var booking = await _context
            .Bookings.Include(x => x.Payment)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (booking == null)
        {
            throw new NotFoundException();
        }

        var payments = await _context
            .Payments.Where(t => paymentsId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var payment in payments)
        {
            booking.Payment?.Remove(payment);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple References records from Booking
    /// </summary>
    public async Task DisconnectReferences(
        BookingWhereUniqueInput uniqueId,
        BookingReferenceWhereUniqueInput[] bookingReferencesId
    )
    {
        var booking = await _context
            .Bookings.Include(x => x.References)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (booking == null)
        {
            throw new NotFoundException();
        }

        var bookingReferences = await _context
            .BookingReferences.Where(t => bookingReferencesId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var bookingReference in bookingReferences)
        {
            booking.References?.Remove(bookingReference);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Workflow Reminders records from Booking
    /// </summary>
    public async Task DisconnectWorkflowReminders(
        BookingWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        var booking = await _context
            .Bookings.Include(x => x.WorkflowReminders)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (booking == null)
        {
            throw new NotFoundException();
        }

        var workflowReminders = await _context
            .WorkflowReminders.Where(t => workflowRemindersId.Select(x => x.Id).Contains(t.Id))
            .ToListAsync();

        foreach (var workflowReminder in workflowReminders)
        {
            booking.WorkflowReminders?.Remove(workflowReminder);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Attendees records for Booking
    /// </summary>
    public async Task<List<Attendee>> FindAttendees(
        BookingWhereUniqueInput uniqueId,
        AttendeeFindManyArgs bookingFindManyArgs
    )
    {
        var attendees = await _context
            .Attendees.Where(m => m.BookingId == uniqueId.Id)
            .ApplyWhere(bookingFindManyArgs.Where)
            .ApplySkip(bookingFindManyArgs.Skip)
            .ApplyTake(bookingFindManyArgs.Take)
            .ApplyOrderBy(bookingFindManyArgs.SortBy)
            .ToListAsync();

        return attendees.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Payment records for Booking
    /// </summary>
    public async Task<List<Payment>> FindPayment(
        BookingWhereUniqueInput uniqueId,
        PaymentFindManyArgs bookingFindManyArgs
    )
    {
        var payments = await _context
            .Payments.Where(m => m.BookingId == uniqueId.Id)
            .ApplyWhere(bookingFindManyArgs.Where)
            .ApplySkip(bookingFindManyArgs.Skip)
            .ApplyTake(bookingFindManyArgs.Take)
            .ApplyOrderBy(bookingFindManyArgs.SortBy)
            .ToListAsync();

        return payments.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple References records for Booking
    /// </summary>
    public async Task<List<BookingReference>> FindReferences(
        BookingWhereUniqueInput uniqueId,
        BookingReferenceFindManyArgs bookingFindManyArgs
    )
    {
        var bookingReferences = await _context
            .BookingReferences.Where(m => m.BookingId == uniqueId.Id)
            .ApplyWhere(bookingFindManyArgs.Where)
            .ApplySkip(bookingFindManyArgs.Skip)
            .ApplyTake(bookingFindManyArgs.Take)
            .ApplyOrderBy(bookingFindManyArgs.SortBy)
            .ToListAsync();

        return bookingReferences.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Find multiple Workflow Reminders records for Booking
    /// </summary>
    public async Task<List<WorkflowReminder>> FindWorkflowReminders(
        BookingWhereUniqueInput uniqueId,
        WorkflowReminderFindManyArgs bookingFindManyArgs
    )
    {
        var workflowReminders = await _context
            .WorkflowReminders.Where(m => m.BookingId == uniqueId.Id)
            .ApplyWhere(bookingFindManyArgs.Where)
            .ApplySkip(bookingFindManyArgs.Skip)
            .ApplyTake(bookingFindManyArgs.Take)
            .ApplyOrderBy(bookingFindManyArgs.SortBy)
            .ToListAsync();

        return workflowReminders.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Get a Daily Ref record for Booking
    /// </summary>
    public async Task<DailyEventReference> GetDailyRef(BookingWhereUniqueInput uniqueId)
    {
        var booking = await _context
            .Bookings.Where(booking => booking.Id == uniqueId.Id)
            .Include(booking => booking.DailyRef)
            .FirstOrDefaultAsync();
        if (booking == null)
        {
            throw new NotFoundException();
        }
        return booking.DailyRef.ToDto();
    }

    /// <summary>
    /// Get a Destination Calendar record for Booking
    /// </summary>
    public async Task<DestinationCalendar> GetDestinationCalendar(BookingWhereUniqueInput uniqueId)
    {
        var booking = await _context
            .Bookings.Where(booking => booking.Id == uniqueId.Id)
            .Include(booking => booking.DestinationCalendar)
            .FirstOrDefaultAsync();
        if (booking == null)
        {
            throw new NotFoundException();
        }
        return booking.DestinationCalendar.ToDto();
    }

    /// <summary>
    /// Get a Event Type record for Booking
    /// </summary>
    public async Task<EventType> GetEventType(BookingWhereUniqueInput uniqueId)
    {
        var booking = await _context
            .Bookings.Where(booking => booking.Id == uniqueId.Id)
            .Include(booking => booking.EventType)
            .FirstOrDefaultAsync();
        if (booking == null)
        {
            throw new NotFoundException();
        }
        return booking.EventType.ToDto();
    }

    /// <summary>
    /// Get a User record for Booking
    /// </summary>
    public async Task<User> GetUser(BookingWhereUniqueInput uniqueId)
    {
        var booking = await _context
            .Bookings.Where(booking => booking.Id == uniqueId.Id)
            .Include(booking => booking.User)
            .FirstOrDefaultAsync();
        if (booking == null)
        {
            throw new NotFoundException();
        }
        return booking.User.ToDto();
    }

    /// <summary>
    /// Meta data about Booking records
    /// </summary>
    public async Task<MetadataDto> BookingsMeta(BookingFindManyArgs findManyArgs)
    {
        var count = await _context.Bookings.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update multiple Attendees records for Booking
    /// </summary>
    public async Task UpdateAttendees(
        BookingWhereUniqueInput uniqueId,
        AttendeeWhereUniqueInput[] attendeesId
    )
    {
        var booking = await _context
            .Bookings.Include(t => t.Attendees)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (booking == null)
        {
            throw new NotFoundException();
        }

        var attendees = await _context
            .Attendees.Where(a => attendeesId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (attendees.Count == 0)
        {
            throw new NotFoundException();
        }

        booking.Attendees = attendees;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Payment records for Booking
    /// </summary>
    public async Task UpdatePayment(
        BookingWhereUniqueInput uniqueId,
        PaymentWhereUniqueInput[] paymentsId
    )
    {
        var booking = await _context
            .Bookings.Include(t => t.Payment)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (booking == null)
        {
            throw new NotFoundException();
        }

        var payments = await _context
            .Payments.Where(a => paymentsId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (payments.Count == 0)
        {
            throw new NotFoundException();
        }

        booking.Payment = payments;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple References records for Booking
    /// </summary>
    public async Task UpdateReferences(
        BookingWhereUniqueInput uniqueId,
        BookingReferenceWhereUniqueInput[] bookingReferencesId
    )
    {
        var booking = await _context
            .Bookings.Include(t => t.References)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (booking == null)
        {
            throw new NotFoundException();
        }

        var bookingReferences = await _context
            .BookingReferences.Where(a => bookingReferencesId.Select(x => x.Id).Contains(a.Id))
            .ToListAsync();

        if (bookingReferences.Count == 0)
        {
            throw new NotFoundException();
        }

        booking.References = bookingReferences;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Workflow Reminders records for Booking
    /// </summary>
    public async Task UpdateWorkflowReminders(
        BookingWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        var booking = await _context
            .Bookings.Include(t => t.WorkflowReminders)
            .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (booking == null)
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

        booking.WorkflowReminders = workflowReminders;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Create one Booking
    /// </summary>
    public async Task<Booking> CreateBooking(BookingCreateInput createDto)
    {
        var booking = new BookingDbModel
        {
            Uid = createDto.Uid,
            Title = createDto.Title,
            Description = createDto.Description,
            CustomInputs = createDto.CustomInputs,
            StartTime = createDto.StartTime,
            EndTime = createDto.EndTime,
            Location = createDto.Location,
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt,
            Status = createDto.Status,
            Paid = createDto.Paid,
            CancellationReason = createDto.CancellationReason,
            RejectionReason = createDto.RejectionReason,
            DynamicEventSlugRef = createDto.DynamicEventSlugRef,
            DynamicGroupSlugRef = createDto.DynamicGroupSlugRef,
            Rescheduled = createDto.Rescheduled,
            FromReschedule = createDto.FromReschedule,
            RecurringEventId = createDto.RecurringEventId,
            SmsReminderNumber = createDto.SmsReminderNumber
        };

        if (createDto.Id != null)
        {
            booking.Id = createDto.Id.Value;
        }
        if (createDto.EventType != null)
        {
            booking.EventType = await _context
                .EventTypes.Where(eventType => createDto.EventType.Id == eventType.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.DestinationCalendar != null)
        {
            booking.DestinationCalendar = await _context
                .DestinationCalendars.Where(destinationCalendar =>
                    createDto.DestinationCalendar.Id == destinationCalendar.Id
                )
                .FirstOrDefaultAsync();
        }

        if (createDto.User != null)
        {
            booking.User = await _context
                .Users.Where(user => createDto.User.Id == user.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.References != null)
        {
            booking.References = await _context
                .BookingReferences.Where(bookingReference =>
                    createDto.References.Select(t => t.Id).Contains(bookingReference.Id)
                )
                .ToListAsync();
        }

        if (createDto.Attendees != null)
        {
            booking.Attendees = await _context
                .Attendees.Where(attendee =>
                    createDto.Attendees.Select(t => t.Id).Contains(attendee.Id)
                )
                .ToListAsync();
        }

        if (createDto.DailyRef != null)
        {
            booking.DailyRef = await _context
                .DailyEventReferences.Where(dailyEventReference =>
                    createDto.DailyRef.Id == dailyEventReference.Id
                )
                .FirstOrDefaultAsync();
        }

        if (createDto.Payment != null)
        {
            booking.Payment = await _context
                .Payments.Where(payment => createDto.Payment.Select(t => t.Id).Contains(payment.Id))
                .ToListAsync();
        }

        if (createDto.WorkflowReminders != null)
        {
            booking.WorkflowReminders = await _context
                .WorkflowReminders.Where(workflowReminder =>
                    createDto.WorkflowReminders.Select(t => t.Id).Contains(workflowReminder.Id)
                )
                .ToListAsync();
        }

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<BookingDbModel>(booking.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Booking
    /// </summary>
    public async Task DeleteBooking(BookingWhereUniqueInput uniqueId)
    {
        var booking = await _context.Bookings.FindAsync(uniqueId.Id);
        if (booking == null)
        {
            throw new NotFoundException();
        }

        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Bookings
    /// </summary>
    public async Task<List<Booking>> Bookings(BookingFindManyArgs findManyArgs)
    {
        var bookings = await _context
            .Bookings.Include(x => x.EventType)
            .Include(x => x.DestinationCalendar)
            .Include(x => x.User)
            .Include(x => x.References)
            .Include(x => x.Attendees)
            .Include(x => x.DailyRef)
            .Include(x => x.Payment)
            .Include(x => x.WorkflowReminders)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return bookings.ConvertAll(booking => booking.ToDto());
    }

    /// <summary>
    /// Get one Booking
    /// </summary>
    public async Task<Booking> Booking(BookingWhereUniqueInput uniqueId)
    {
        var bookings = await this.Bookings(
            new BookingFindManyArgs { Where = new BookingWhereInput { Id = uniqueId.Id } }
        );
        var booking = bookings.FirstOrDefault();
        if (booking == null)
        {
            throw new NotFoundException();
        }

        return booking;
    }

    /// <summary>
    /// Update one Booking
    /// </summary>
    public async Task UpdateBooking(BookingWhereUniqueInput uniqueId, BookingUpdateInput updateDto)
    {
        var booking = updateDto.ToModel(uniqueId);

        if (updateDto.References != null)
        {
            booking.References = await _context
                .BookingReferences.Where(bookingReference =>
                    updateDto.References.Select(t => t).Contains(bookingReference.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Attendees != null)
        {
            booking.Attendees = await _context
                .Attendees.Where(attendee =>
                    updateDto.Attendees.Select(t => t).Contains(attendee.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Payment != null)
        {
            booking.Payment = await _context
                .Payments.Where(payment => updateDto.Payment.Select(t => t).Contains(payment.Id))
                .ToListAsync();
        }

        if (updateDto.WorkflowReminders != null)
        {
            booking.WorkflowReminders = await _context
                .WorkflowReminders.Where(workflowReminder =>
                    updateDto.WorkflowReminders.Select(t => t).Contains(workflowReminder.Id)
                )
                .ToListAsync();
        }

        _context.Entry(booking).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Bookings.Any(e => e.Id == booking.Id))
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
