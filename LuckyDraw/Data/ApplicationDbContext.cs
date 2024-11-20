using LuckyDraw.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LuckyDraw.Data;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Participant> Participants { get; set; }
    public DbSet<Prize> Prizes { get; set; }
    public DbSet<Winner> Winners { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new RoleBuilder());
        builder.ApplyConfiguration(new RoleClaimBuilder());
        builder.ApplyConfiguration(new UserBuilder());
        builder.ApplyConfiguration(new UserClaimBuilder());
        builder.ApplyConfiguration(new UserLoginBuilder());
        builder.ApplyConfiguration(new UserRoleBuilder());
        builder.ApplyConfiguration(new UserTokenBuilder());
    }
}
