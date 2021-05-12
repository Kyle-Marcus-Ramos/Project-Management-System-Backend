using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Management.System.Model.Entities;
using System.Data;

namespace Project.Management.System.Model.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("CommentId")
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
        }
    }
}
