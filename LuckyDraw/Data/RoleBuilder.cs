using LuckyDraw.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyDraw.Data;

public class RoleBuilder : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.ToTable("Role");

        builder.Property(r => r.ConcurrencyStamp).HasMaxLength(36);

        builder.HasData(
        [
            new IdentityRole
            {
                Id = "19790536-5348-4397-857f-ba8dc02fa52e",
                Name = UserRole.User,
                NormalizedName = UserRole.User.ToUpper()
            }
        ]);
    }
}
