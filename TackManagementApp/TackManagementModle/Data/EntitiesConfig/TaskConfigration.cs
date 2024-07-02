using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TackManagementModle.Enums;

namespace TackManagementModle.Data.EntitiesConfig
{
    public class TaskConfigration : IEntityTypeConfiguration<Entities.Tasks>
    {
        public void Configure(EntityTypeBuilder<Entities.Tasks> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(x => x.Status)
                .HasConversion(
                    x => (byte)x,
                    x => (Enums.TaskStatus)x
                );
        }


    }
}
