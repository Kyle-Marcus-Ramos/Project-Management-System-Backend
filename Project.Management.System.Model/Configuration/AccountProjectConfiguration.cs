using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Management.System.Model.Entities;
using System.Data;


namespace Project.Management.System.Model.Configuration
{
    public class AccountProjectConfiguration : IEntityTypeConfiguration<AccountProject>
    {
        public void Configure(EntityTypeBuilder<AccountProject> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("AccountProjectId")
               .HasColumnType(SqlDbType.Int.ToString())
               .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Card)
             .WithMany()
             .HasForeignKey(x => x.CardId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Project)
             .WithMany()
             .HasForeignKey(x => x.ProjectId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
