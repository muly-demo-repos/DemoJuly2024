using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Nnnettt.Infrastructure;

public class NnnetttDbContext : IdentityDbContext<IdentityUser>
{
    public NnnetttDbContext(DbContextOptions<NnnetttDbContext> options)
        : base(options) { }
}
