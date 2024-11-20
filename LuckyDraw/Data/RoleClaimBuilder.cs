using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyDraw.Data;

public class RoleClaimBuilder : IEntityTypeConfiguration<IdentityRoleClaim<string>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
    {
        builder.ToTable("RoleClaim");

        builder.Property(rc => rc.ClaimType).HasMaxLength(256);
        builder.Property(rc => rc.ClaimValue).HasMaxLength(1024);
    }
}
