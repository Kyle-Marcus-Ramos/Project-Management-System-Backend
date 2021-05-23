using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Project.Management.System.Model.Configuration;
using Project.Management.System.Model.Entities;
using System.IO;

namespace Project.Management.System.Data.Context
{
    public class ProjectManagementDBContext : DbContext, IDesignTimeDbContextFactory<ProjectManagementDBContext>
    {
        private string _connectionString;

        
        public ProjectManagementDBContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ProjectManagementDBContext()
        { }

        public ProjectManagementDBContext(DbContextOptions<ProjectManagementDBContext> options)
            : base(options)
        { }

        //Comment if updating DB
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlServer(_connectionString, sqlServerOption => sqlServerOption.CommandTimeout(1000000));

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountProject> AccountProject { get; set; }
        public virtual DbSet<Card> Card { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Projects> Project { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new AccountProjectConfiguration());
            builder.ApplyConfiguration(new CardConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new ProjectConfiguration());
            base.OnModelCreating(builder);
        }

        public ProjectManagementDBContext CreateDbContext(string[] args)
        {
           
            IConfigurationRoot configuration = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("secrets/secrets.json", optional: false, reloadOnChange: true)
                  .Build();
            var connectionString = configuration.GetConnectionString("DevConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ProjectManagementDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ProjectManagementDBContext(optionsBuilder.Options);
        }
    }
}
