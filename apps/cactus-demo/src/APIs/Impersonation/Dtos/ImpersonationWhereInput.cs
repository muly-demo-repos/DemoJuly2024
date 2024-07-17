namespace CactusDemo.APIs.Dtos;

public class ImpersonationWhereInput
{
    public int? Id { get; set; }

    public DateTime? CreatedAt { get; set; }

    public int? UsersImpersonationsImpersonatedByIdTousers { get; set; }

    public int? UsersImpersonationsImpersonatedUserIdTousers { get; set; }
}
