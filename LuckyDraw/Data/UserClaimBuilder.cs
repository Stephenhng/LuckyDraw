using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyDraw.Data;

public class UserClaimBuilder : IEntityTypeConfiguration<IdentityUserClaim<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserClaim<string>> builder)
    {
        builder.ToTable("UserClaim");

        builder.Property(uc => uc.ClaimType).HasMaxLength(256);
        builder.Property(uc => uc.ClaimValue).HasMaxLength(1024);
    }
}
