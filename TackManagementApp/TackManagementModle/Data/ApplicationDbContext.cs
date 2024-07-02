using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TackManagementModle.Data.EntitiesConfig;
using TackManagementModle.Entities;


namespace TackManagementModle.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<AppUser>().ToTable("Users", "Secority");
            //builder.Entity<IdentityRole>().ToTable("Roles", "Secority");
            //builder.Entity<IdentityUserRole<string>>().ToTable("RoleUsers", "Secority");
            //builder.Entity<IdentityUserToken<string>>().ToTable("UserToken", "Secority");
            //builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Secority");
            //builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "Secority");
            //builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin", "Secority");
            //builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim", "Secority");

            new TaskConfigration().Configure(builder.Entity<Tasks>());
        }
    }
}