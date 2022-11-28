using api.Data.Configurations;
using api.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace api.Data
{
    public class VacationManagerDbContext : IdentityDbContext<User>
    {
        public VacationManagerDbContext(DbContextOptions option) : base(option)
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
            .HasMany(c => c.Users)
            .WithOne(e => e.Team);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<api.Data.Models.Project> Project { get; set; }
    }
}
