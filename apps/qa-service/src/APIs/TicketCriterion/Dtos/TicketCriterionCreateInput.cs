namespace QaService.APIs.Dtos;

public class TicketCriterionCreateInput
{
    public string? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public TicketCategory? TicketCategory { get; set; }

    public string? Criteria { get; set; }
}
