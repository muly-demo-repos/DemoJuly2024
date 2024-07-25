namespace CactusDemo.APIs.Dtos;

public class ImpersonationUpdateInput
{
    public int? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? UsersImpersonationsImpersonatedByIdTousers { get; set; }

    public int? UsersImpersonationsImpersonatedUserIdTousers { get; set; }
}
