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

        builder.HasData(
        [
            new IdentityRole
            {
                Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                Name = UserRole.Admin,
                NormalizedName = UserRole.Admin.ToUpper()
            }
        ]);
    }
}
