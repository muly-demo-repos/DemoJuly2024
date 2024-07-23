using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moshe.Infrastructure.Models;

namespace Moshe.Infrastructure;

public class MosheDbContext : IdentityDbContext<IdentityUser>
{
    public MosheDbContext(DbContextOptions<MosheDbContext> options)
        : base(options) { }

    public DbSet<CustomerDbModel> Customers { get; set; }
}
