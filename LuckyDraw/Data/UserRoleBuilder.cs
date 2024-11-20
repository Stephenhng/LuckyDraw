using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyDraw.Data;

public class UserRoleBuilder : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.ToTable("UserRole");

        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                UserId = "0e0a5a69-8c2a-4a44-ae2e-c9e5bba3a947"
            },
            new IdentityUserRole<string>
            {
                RoleId = "19790536-5348-4397-857f-ba8dc02fa52e",
                UserId = "1f4e20e2-5c0e-4c79-a5c9-28b0f4a8b1dd"
            },
            new IdentityUserRole<string>
            {
                RoleId = "19790536-5348-4397-857f-ba8dc02fa52e",
                UserId = "2d3c56d8-6b6a-4c1e-a29e-5d3b0c6a8d2c"
            },
            new IdentityUserRole<string>
            {
                RoleId = "19790536-5348-4397-857f-ba8dc02fa52e",
                UserId = "3e3b28fa-3c2a-4b49-b7b2-a8c3b4e6e92d"
            }
        );
    }
}
