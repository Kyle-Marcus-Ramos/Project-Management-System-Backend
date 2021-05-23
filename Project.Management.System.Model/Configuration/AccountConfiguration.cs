using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Management.System.Model.Entities;
using System.Data;

namespace Project.Management.System.Model.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
               .HasColumnName("AccountId")
               .HasColumnType(SqlDbType.Int.ToString())
               .ValueGeneratedOnAdd();
        }
    }
}
