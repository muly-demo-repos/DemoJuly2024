namespace QaService.APIs.Dtos;

public class TicketCategoryCreateInput
{
    public string? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string? CategoryName { get; set; }

    public List<TicketCriterion>? TicketCriteria { get; set; }
}
