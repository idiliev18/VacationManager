using api.Data.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api.Data
{
    public class VacationManagerDbContext : IdentityDbContext<User>
    {
        public VacationManagerDbContext(DbContextOptions option) : base(option)
        {

        }

        DbSet<Team> Teams { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<ProjectTeam> ProjectTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.Entity<ProjectTeam>().HasKey(pt => new { pt.TeamId, pt.ProjectId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
