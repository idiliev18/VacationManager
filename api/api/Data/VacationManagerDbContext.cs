using api.Data.Configurations;
using api.Data.Models;
using api.Data.Models.Mapping;
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
        public DbSet<ProjectTeam> ProjectsTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
            .HasMany(c => c.Users)
            .WithOne(e => e.Team);

            modelBuilder.Entity<ProjectTeam>()
                .HasKey(pt => new { pt.ProjectId, pt.TeamId });

            modelBuilder.Entity<ProjectTeam>()
                .HasOne(pt => pt.Project)
                .WithMany(p => p.ProjectTeams)
                .HasForeignKey(pt => pt.ProjectId);

            modelBuilder.Entity<ProjectTeam>()
                .HasOne(pt => pt.Team)
                .WithMany(t => t.TeamProjects)
                .HasForeignKey(pt => pt.TeamId);


            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
