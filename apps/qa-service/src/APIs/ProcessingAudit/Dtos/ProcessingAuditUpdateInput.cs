namespace QaService.APIs.Dtos;

public class ProcessingAuditUpdateInput
{
    public string? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? TicketNumber { get; set; }

    public string? TypeField { get; set; }

    public string? Subtype { get; set; }

    public string? Item { get; set; }

    public string? Criteria { get; set; }

    public string? Result { get; set; }
}
