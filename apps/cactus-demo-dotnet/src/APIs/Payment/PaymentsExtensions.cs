using CactusDemoDotnet.APIs.Dtos;
using CactusDemoDotnet.Infrastructure.Models;

namespace CactusDemoDotnet.APIs.Extensions;

public static class PaymentsExtensions
{
    public static Payment ToDto(this PaymentDbModel model)
    {
        return new Payment
        {
            Id = model.Id,
            Uid = model.Uid,
            Type = model.Type,
            Booking = model.BookingId,
            Amount = model.Amount,
            Fee = model.Fee,
            Currency = model.Currency,
            Success = model.Success,
            Refunded = model.Refunded,
            Data = model.Data,
            ExternalId = model.ExternalId,
        };
    }

    public static PaymentDbModel ToModel(
        this PaymentUpdateInput updateDto,
        PaymentWhereUniqueInput uniqueId
    )
    {
        var payment = new PaymentDbModel { Id = uniqueId.Id };

        // map required fields
        if (updateDto.Uid != null)
        {
            payment.Uid = updateDto.Uid;
        }
        if (updateDto.Type != null)
        {
            payment.Type = updateDto.Type.Value;
        }
        if (updateDto.Amount != null)
        {
            payment.Amount = updateDto.Amount.Value;
        }
        if (updateDto.Fee != null)
        {
            payment.Fee = updateDto.Fee.Value;
        }
        if (updateDto.Currency != null)
        {
            payment.Currency = updateDto.Currency;
        }
        if (updateDto.Success != null)
        {
            payment.Success = updateDto.Success.Value;
        }
        if (updateDto.Refunded != null)
        {
            payment.Refunded = updateDto.Refunded.Value;
        }
        if (updateDto.Data != null)
        {
            payment.Data = updateDto.Data;
        }
        if (updateDto.ExternalId != null)
        {
            payment.ExternalId = updateDto.ExternalId;
        }

        return payment;
    }
}
