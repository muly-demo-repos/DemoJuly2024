using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QaService.Infrastructure.Models;

namespace QaService.Infrastructure;

public class QaServiceDbContext : IdentityDbContext<IdentityUser>
{
    public QaServiceDbContext(DbContextOptions<QaServiceDbContext> options)
        : base(options) { }

    public DbSet<TicketCriterionDbModel> TicketCriteria { get; set; }

    public DbSet<TicketCategoryDbModel> TicketCategories { get; set; }
}
