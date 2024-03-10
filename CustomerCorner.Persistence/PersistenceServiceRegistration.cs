using CustomerCorner.Application.Contracts.Persistence;
using CustomerCorner.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCorner.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<CustomerCornerDbContext>(options =>
           
                options.UseSqlServer(configuration.GetConnectionString
                    ("CustomerCornerConnectionString")));



            services.AddScoped(typeof(IAsyncRepository <>) , typeof(BaseRepository <>));
            services.AddScoped<IUserRepository, UserRepository>();


            return services;
        }
    }
}
