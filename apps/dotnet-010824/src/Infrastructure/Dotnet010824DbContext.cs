using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dotnet010824.Infrastructure;

public class Dotnet010824DbContext : IdentityDbContext<IdentityUser>
{
    public Dotnet010824DbContext(DbContextOptions<Dotnet010824DbContext> options)
        : base(options) { }
}
