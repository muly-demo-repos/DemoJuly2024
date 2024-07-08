namespace QaService.APIs.Dtos;

public class TicketCriterionUpdateInput
{
    public string? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? TicketCategory { get; set; }

    public string? Criteria { get; set; }
}
