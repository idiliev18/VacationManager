using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace api.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {

            builder.HasData(
                new IdentityRole
                {
                    Name = "CEO",
                    NormalizedName = "CEO"
                },
                 new IdentityRole
                 {
                     Name = "Team Lead",
                     NormalizedName = "TEAM LEAD"
                 },
                 new IdentityRole
                 {
                     Name = "Developer",
                     NormalizedName = "DEVELOPER"
                 },
                 new IdentityRole
                 {
                     Name = "Unassigned",
                     NormalizedName = "UNASSIGNED"
                 }
                );
        }
    }
}
