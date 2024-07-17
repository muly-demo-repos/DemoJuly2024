using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class BookingsServiceBase : IBookingsService
{
    protected readonly CactusDemoDbContext _context;

    public BookingsServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Connect multiple Attendee records to Booking
    /// </summary>
    public async Task ConnectAttendee(
        BookingWhereUniqueInput uniqueId,
        AttendeeWhereUniqueInput[] attendeesId
    )
    {
        var booking = await _context
            .Bookings.Include(x => x.Attendee)
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

        var attendeesToConnect = attendees.Except(booking.Attendee);

        foreach (var attendee in attendeesToConnect)
        {
            booking.Attendee.Add(attendee);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple Booking Reference records to Booking
    /// </summary>
    public async Task ConnectBookingReference(
        BookingWhereUniqueInput uniqueId,
        BookingReferenceWhereUniqueInput[] bookingReferencesId
    )
    {
        var booking = await _context
            .Bookings.Include(x => x.BookingReference)
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

        var bookingReferencesToConnect = bookingReferences.Except(booking.BookingReference);

        foreach (var bookingReference in bookingReferencesToConnect)
        {
            booking.BookingReference.Add(bookingReference);
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
    /// Connect multiple Workflow Reminder records to Booking
    /// </summary>
    public async Task ConnectWorkflowReminder(
        BookingWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        var booking = await _context
            .Bookings.Include(x => x.WorkflowReminder)
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

        var workflowRemindersToConnect = workflowReminders.Except(booking.WorkflowReminder);

        foreach (var workflowReminder in workflowRemindersToConnect)
        {
            booking.WorkflowReminder.Add(workflowReminder);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Attendee records from Booking
    /// </summary>
    public async Task DisconnectAttendee(
        BookingWhereUniqueInput uniqueId,
        AttendeeWhereUniqueInput[] attendeesId
    )
    {
        var booking = await _context
            .Bookings.Include(x => x.Attendee)
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
            booking.Attendee?.Remove(attendee);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple Booking Reference records from Booking
    /// </summary>
    public async Task DisconnectBookingReference(
        BookingWhereUniqueInput uniqueId,
        BookingReferenceWhereUniqueInput[] bookingReferencesId
    )
    {
        var booking = await _context
            .Bookings.Include(x => x.BookingReference)
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
            booking.BookingReference?.Remove(bookingReference);
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
    /// Disconnect multiple Workflow Reminder records from Booking
    /// </summary>
    public async Task DisconnectWorkflowReminder(
        BookingWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        var booking = await _context
            .Bookings.Include(x => x.WorkflowReminder)
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
            booking.WorkflowReminder?.Remove(workflowReminder);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple Attendee records for Booking
    /// </summary>
    public async Task<List<Attendee>> FindAttendee(
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
    /// Find multiple Booking Reference records for Booking
    /// </summary>
    public async Task<List<BookingReference>> FindBookingReference(
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
    /// Find multiple Workflow Reminder records for Booking
    /// </summary>
    public async Task<List<WorkflowReminder>> FindWorkflowReminder(
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
    /// Get a Daily Event Reference record for Booking
    /// </summary>
    public async Task<DailyEventReference> GetDailyEventReference(BookingWhereUniqueInput uniqueId)
    {
        var booking = await _context
            .Bookings.Where(booking => booking.Id == uniqueId.Id)
            .Include(booking => booking.DailyEventReference)
            .FirstOrDefaultAsync();
        if (booking == null)
        {
            throw new NotFoundException();
        }
        return booking.DailyEventReference.ToDto();
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
    /// Get a Users record for Booking
    /// </summary>
    public async Task<User> GetUsers(BookingWhereUniqueInput uniqueId)
    {
        var booking = await _context
            .Bookings.Where(booking => booking.Id == uniqueId.Id)
            .Include(booking => booking.Users)
            .FirstOrDefaultAsync();
        if (booking == null)
        {
            throw new NotFoundException();
        }
        return booking.Users.ToDto();
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
    /// Update multiple Attendee records for Booking
    /// </summary>
    public async Task UpdateAttendee(
        BookingWhereUniqueInput uniqueId,
        AttendeeWhereUniqueInput[] attendeesId
    )
    {
        var booking = await _context
            .Bookings.Include(t => t.Attendee)
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

        booking.Attendee = attendees;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Update multiple Booking Reference records for Booking
    /// </summary>
    public async Task UpdateBookingReference(
        BookingWhereUniqueInput uniqueId,
        BookingReferenceWhereUniqueInput[] bookingReferencesId
    )
    {
        var booking = await _context
            .Bookings.Include(t => t.BookingReference)
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

        booking.BookingReference = bookingReferences;
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
    /// Update multiple Workflow Reminder records for Booking
    /// </summary>
    public async Task UpdateWorkflowReminder(
        BookingWhereUniqueInput uniqueId,
        WorkflowReminderWhereUniqueInput[] workflowRemindersId
    )
    {
        var booking = await _context
            .Bookings.Include(t => t.WorkflowReminder)
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

        booking.WorkflowReminder = workflowReminders;
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
        if (createDto.Attendee != null)
        {
            booking.Attendee = await _context
                .Attendees.Where(attendee =>
                    createDto.Attendee.Select(t => t.Id).Contains(attendee.Id)
                )
                .ToListAsync();
        }

        if (createDto.BookingReference != null)
        {
            booking.BookingReference = await _context
                .BookingReferences.Where(bookingReference =>
                    createDto.BookingReference.Select(t => t.Id).Contains(bookingReference.Id)
                )
                .ToListAsync();
        }

        if (createDto.DailyEventReference != null)
        {
            booking.DailyEventReference = await _context
                .DailyEventReferences.Where(dailyEventReference =>
                    createDto.DailyEventReference.Id == dailyEventReference.Id
                )
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

        if (createDto.EventType != null)
        {
            booking.EventType = await _context
                .EventTypes.Where(eventType => createDto.EventType.Id == eventType.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.Payment != null)
        {
            booking.Payment = await _context
                .Payments.Where(payment => createDto.Payment.Select(t => t.Id).Contains(payment.Id))
                .ToListAsync();
        }

        if (createDto.WorkflowReminder != null)
        {
            booking.WorkflowReminder = await _context
                .WorkflowReminders.Where(workflowReminder =>
                    createDto.WorkflowReminder.Select(t => t.Id).Contains(workflowReminder.Id)
                )
                .ToListAsync();
        }

        if (createDto.Users != null)
        {
            booking.Users = await _context
                .Users.Where(user => createDto.Users.Id == user.Id)
                .FirstOrDefaultAsync();
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
            .Bookings.Include(x => x.Attendee)
            .Include(x => x.BookingReference)
            .Include(x => x.DailyEventReference)
            .Include(x => x.DestinationCalendar)
            .Include(x => x.EventType)
            .Include(x => x.Payment)
            .Include(x => x.WorkflowReminder)
            .Include(x => x.Users)
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

        if (updateDto.Attendee != null)
        {
            booking.Attendee = await _context
                .Attendees.Where(attendee =>
                    updateDto.Attendee.Select(t => t).Contains(attendee.Id)
                )
                .ToListAsync();
        }

        if (updateDto.BookingReference != null)
        {
            booking.BookingReference = await _context
                .BookingReferences.Where(bookingReference =>
                    updateDto.BookingReference.Select(t => t).Contains(bookingReference.Id)
                )
                .ToListAsync();
        }

        if (updateDto.Payment != null)
        {
            booking.Payment = await _context
                .Payments.Where(payment => updateDto.Payment.Select(t => t).Contains(payment.Id))
                .ToListAsync();
        }

        if (updateDto.WorkflowReminder != null)
        {
            booking.WorkflowReminder = await _context
                .WorkflowReminders.Where(workflowReminder =>
                    updateDto.WorkflowReminder.Select(t => t).Contains(workflowReminder.Id)
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
