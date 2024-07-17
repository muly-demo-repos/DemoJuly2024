using CactusDemo.APIs;
using CactusDemo.APIs.Common;
using CactusDemo.APIs.Dtos;
using CactusDemo.APIs.Errors;
using CactusDemo.APIs.Extensions;
using CactusDemo.Infrastructure;
using CactusDemo.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace CactusDemo.APIs;

public abstract class PaymentsServiceBase : IPaymentsService
{
    protected readonly CactusDemoDbContext _context;

    public PaymentsServiceBase(CactusDemoDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Payment
    /// </summary>
    public async Task<Payment> CreatePayment(PaymentCreateInput createDto)
    {
        var payment = new PaymentDbModel
        {
            Uid = createDto.Uid,
            Type = createDto.Type,
            Amount = createDto.Amount,
            Fee = createDto.Fee,
            Currency = createDto.Currency,
            Success = createDto.Success,
            Refunded = createDto.Refunded,
            Data = createDto.Data,
            ExternalId = createDto.ExternalId
        };

        if (createDto.Id != null)
        {
            payment.Id = createDto.Id.Value;
        }
        if (createDto.Booking != null)
        {
            payment.Booking = await _context
                .Bookings.Where(booking => createDto.Booking.Id == booking.Id)
                .FirstOrDefaultAsync();
        }

        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PaymentDbModel>(payment.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Payment
    /// </summary>
    public async Task DeletePayment(PaymentWhereUniqueInput uniqueId)
    {
        var payment = await _context.Payments.FindAsync(uniqueId.Id);
        if (payment == null)
        {
            throw new NotFoundException();
        }

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Payments
    /// </summary>
    public async Task<List<Payment>> Payments(PaymentFindManyArgs findManyArgs)
    {
        var payments = await _context
            .Payments.Include(x => x.Booking)
            .ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return payments.ConvertAll(payment => payment.ToDto());
    }

    /// <summary>
    /// Get one Payment
    /// </summary>
    public async Task<Payment> Payment(PaymentWhereUniqueInput uniqueId)
    {
        var payments = await this.Payments(
            new PaymentFindManyArgs { Where = new PaymentWhereInput { Id = uniqueId.Id } }
        );
        var payment = payments.FirstOrDefault();
        if (payment == null)
        {
            throw new NotFoundException();
        }

        return payment;
    }

    /// <summary>
    /// Get a Booking record for Payment
    /// </summary>
    public async Task<Booking> GetBooking(PaymentWhereUniqueInput uniqueId)
    {
        var payment = await _context
            .Payments.Where(payment => payment.Id == uniqueId.Id)
            .Include(payment => payment.Booking)
            .FirstOrDefaultAsync();
        if (payment == null)
        {
            throw new NotFoundException();
        }
        return payment.Booking.ToDto();
    }

    /// <summary>
    /// Meta data about Payment records
    /// </summary>
    public async Task<MetadataDto> PaymentsMeta(PaymentFindManyArgs findManyArgs)
    {
        var count = await _context.Payments.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Update one Payment
    /// </summary>
    public async Task UpdatePayment(PaymentWhereUniqueInput uniqueId, PaymentUpdateInput updateDto)
    {
        var payment = updateDto.ToModel(uniqueId);

        _context.Entry(payment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Payments.Any(e => e.Id == payment.Id))
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
