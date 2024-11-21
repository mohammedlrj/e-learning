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
    }
}
