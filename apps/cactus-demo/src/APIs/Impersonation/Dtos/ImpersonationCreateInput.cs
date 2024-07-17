namespace CactusDemo.APIs.Dtos;

public class ImpersonationCreateInput
{
    public int? Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public User UsersImpersonationsImpersonatedByIdTousers { get; set; }

    public User UsersImpersonationsImpersonatedUserIdTousers { get; set; }
}
