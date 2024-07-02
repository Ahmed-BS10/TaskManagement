using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TackManagementModle.Data.EntitiesConfig;
using TackManagementModle.Entities;


namespace TackManagementModle.Data
{
    public class AppDbContexts : IdentityDbContext<AppUser>
    {
        public AppDbContexts(DbContextOptions<AppDbContexts> options)
            : base(options)
        {
        }


        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new TaskConfigration().Configure(builder.Entity<Tasks>());
        }
    }
}