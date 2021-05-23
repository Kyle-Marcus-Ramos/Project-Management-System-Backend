using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Management.System.Model.Entities;
using System.Data;

namespace Project.Management.System.Model.Configuration
{
    public class CardConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("CardId")
               .HasColumnType(SqlDbType.Int.ToString())
               .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Project)
             .WithMany()
             .HasForeignKey(x => x.ProjectId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
