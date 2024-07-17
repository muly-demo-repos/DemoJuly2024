namespace CactusDemo.APIs.Dtos;

public class Impersonation
{
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public int UsersImpersonationsImpersonatedByIdTousers { get; set; }

    public int UsersImpersonationsImpersonatedUserIdTousers { get; set; }
}
