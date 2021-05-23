using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Management.System.BusinessLogic.Services;
using Project.Management.System.BusinessLogic.Services.Base;
using Project.Management.System.Data;
using Project.Management.System.Data.Base;
using Project.Management.System.Data.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Management_System_Backend
{
    public static class IoC
    {
        private static ServiceProvider serviceProvider;

        public static void AddDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpContextAccessor();

            var connectionString = config.GetConnectionString("DevConnection");

            services.AddTransient<ProjectManagementDBContext>();
            services.AddScoped<IUnitOfWork>(x => new UnitOfWork(connectionString));
            services.AddScoped<IUnitOfWorkDapper>(x => new UnitOfWorkDapper(connectionString));
            services.AddScoped<ILogService, LoggingService>();
            services.AddScoped<IAccountProjectService, AccountProjectService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IProjectService, ProjectService>();


            serviceProvider = services.BuildServiceProvider();
        }
    }
}
