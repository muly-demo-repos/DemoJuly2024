using CactusDemoDotnet.APIs.Common;
using CactusDemoDotnet.APIs.Dtos;

namespace CactusDemoDotnet.APIs;

public interface IPaymentsService
{
    /// <summary>
    /// Create one Payment
    /// </summary>
    public Task<Payment> CreatePayment(PaymentCreateInput payment);

    /// <summary>
    /// Delete one Payment
    /// </summary>
    public Task DeletePayment(PaymentWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Payments
    /// </summary>
    public Task<List<Payment>> Payments(PaymentFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Payment
    /// </summary>
    public Task<Payment> Payment(PaymentWhereUniqueInput uniqueId);

    /// <summary>
    /// Get a Booking record for Payment
    /// </summary>
    public Task<Booking> GetBooking(PaymentWhereUniqueInput uniqueId);

    /// <summary>
    /// Meta data about Payment records
    /// </summary>
    public Task<MetadataDto> PaymentsMeta(PaymentFindManyArgs findManyArgs);

    /// <summary>
    /// Update one Payment
    /// </summary>
    public Task UpdatePayment(PaymentWhereUniqueInput uniqueId, PaymentUpdateInput updateDto);
}
