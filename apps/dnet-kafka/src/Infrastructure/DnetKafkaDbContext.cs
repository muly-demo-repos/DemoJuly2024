using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DnetKafka.Infrastructure;

public class DnetKafkaDbContext : IdentityDbContext<IdentityUser>
{
    public DnetKafkaDbContext(DbContextOptions<DnetKafkaDbContext> options)
        : base(options) { }
}
