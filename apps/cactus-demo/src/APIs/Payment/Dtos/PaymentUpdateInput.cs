using CactusDemo.Core.Enums;

namespace CactusDemo.APIs.Dtos;

public class PaymentUpdateInput
{
    public int? Id { get; set; }

    public string? Uid { get; set; }

    public TypeEnum? Type { get; set; }

    public int? Amount { get; set; }

    public int? Fee { get; set; }

    public string? Currency { get; set; }

    public bool? Success { get; set; }

    public bool? Refunded { get; set; }

    public string? Data { get; set; }

    public string? ExternalId { get; set; }

    public int? Booking { get; set; }
}
