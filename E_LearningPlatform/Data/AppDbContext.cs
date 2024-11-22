using E_LearningPlatform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_LearningPlatform.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            this.SeedAdminUser(builder);
            this.SeedRoles(builder);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = "6ee2a5ea-ab9f-41a4-875e-fd4c1b142631",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Id = "df03e6fe-bb22-42bf-a972-6115b8270ad1", 
                    Name = "Professor",
                    NormalizedName = "PROFESSOR"
                },
                new IdentityRole()
                {
                    Id = "74ae3e61-9437-437b-b26c-3ff104c122f0", 
                    Name = "Student",
                    NormalizedName = "STUDENT"
                }
            );
        }

        private void SeedAdminUser(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<User>();
            var adminEmail = "admin@elearning.com";
            var adminPassword = "Admin123?";

            var adminUser = new User
            {
                Id = "ajhhdgs7-ec6d-4b88-9b20-5322fb1d94e1",
                UserName = "superadmin",
                Email = adminEmail,
                NormalizedUserName = "SUPERADMIN",
                NormalizedEmail = adminEmail.ToUpper(),
                Status = Enums.Status.Approved,
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, adminPassword),
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumber = "0634567891",
                FirstName = "Super",
                LastName = "Admin",
                RegistrationDate = DateTime.UtcNow
            };

            builder.Entity<User>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = adminUser.Id,
                    RoleId = "6ee2a5ea-ab9f-41a4-875e-fd4c1b142631"
                }
            );
        }

    }
}
