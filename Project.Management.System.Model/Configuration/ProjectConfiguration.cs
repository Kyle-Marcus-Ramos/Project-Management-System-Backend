using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Data;

namespace Project.Management.System.Model.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Entities.Project>
    {
        public void Configure(EntityTypeBuilder<Entities.Project> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("ProjectId")
               .HasColumnType(SqlDbType.Int.ToString())
               .ValueGeneratedOnAdd();

            builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
