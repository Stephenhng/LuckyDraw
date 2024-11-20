using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuckyDraw.Data;

public class UserBuilder : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("User");

        builder.Property(u => u.PasswordHash).HasMaxLength(512);
        builder.Property(u => u.SecurityStamp).HasMaxLength(36);
        builder.Property(u => u.ConcurrencyStamp).HasMaxLength(36);
        builder.Property(u => u.PhoneNumber).HasMaxLength(64);

        builder.HasData(
            new ApplicationUser
            {
                Id = "0e0a5a69-8c2a-4a44-ae2e-c9e5bba3a947",
                UserName = "main",
                NormalizedUserName = "MAIN",
                ConcurrencyStamp = "bc1b98fc-6e6f-4ebf-96fa-5c72b63d9af3",
                PasswordHash = "AQAAAAIAAYagAAAAEBzA4F7yDvAljB5wx8TaKhGTxW1dEUH/feK2S5IT1sDmKTkhnkx0CuyivKl+1kPmoQ==",
                SecurityStamp = "a1b2308e-9a4d-4b1f-b671-d16f44e96b8d",
                EmailConfirmed = true,
                TwoFactorEnabled = false
            },
            new ApplicationUser
            {
                Id = "1f4e20e2-5c0e-4c79-a5c9-28b0f4a8b1dd",
                UserName = "view",
                NormalizedUserName = "VIEW",
                ConcurrencyStamp = "5c6a2e3b-1b7d-46a3-9f7e-60a5b0c29bcd",
                PasswordHash = "AQAAAAIAAYagAAAAEBzA4F7yDvAljB5wx8TaKhGTxW1dEUH/feK2S5IT1sDmKTkhnkx0CuyivKl+1kPmoQ==",
                SecurityStamp = "f64e5b1f-7a30-4f5a-91bb-1f3e6388a948",
                EmailConfirmed = true,
                TwoFactorEnabled = false
            },
            new ApplicationUser
            {
                Id = "2d3c56d8-6b6a-4c1e-a29e-5d3b0c6a8d2c",
                UserName = "action",
                NormalizedUserName = "ACTION",
                ConcurrencyStamp = "9f28d1b6-7a31-4ecb-9a92-604bafca76b7",
                PasswordHash = "AQAAAAIAAYagAAAAEBzA4F7yDvAljB5wx8TaKhGTxW1dEUH/feK2S5IT1sDmKTkhnkx0CuyivKl+1kPmoQ==",
                SecurityStamp = "67d7a8b5-0c6d-4638-bb3e-1c726c8cba53",
                EmailConfirmed = true,
                TwoFactorEnabled = false
            },
            new ApplicationUser
            {
                Id = "3e3b28fa-3c2a-4b49-b7b2-a8c3b4e6e92d",
                UserName = "result",
                NormalizedUserName = "RESULT",
                ConcurrencyStamp = "3d98c1e5-5b30-4df7-8a81-1b62a7bc5d1d",
                PasswordHash = "AQAAAAIAAYagAAAAEBzA4F7yDvAljB5wx8TaKhGTxW1dEUH/feK2S5IT1sDmKTkhnkx0CuyivKl+1kPmoQ==",
                SecurityStamp = "be1f6b3d-6c0d-472a-a9d6-2f3a5b8c7d0b",
                EmailConfirmed = true,
                TwoFactorEnabled = false
            }
        );
    }
}
