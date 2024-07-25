namespace CactusDemo.APIs.Dtos;

public class SessionCreateInput
{
    public string? Id { get; set; }

    public string SessionToken { get; set; }

    public DateTime Expires { get; set; }

    public User? Users { get; set; }
}
