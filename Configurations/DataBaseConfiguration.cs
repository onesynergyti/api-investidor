using API_Investidor.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Configurations
{
    public static class DataBaseConfiguration
    {
        public static IServiceCollection AddSQLServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InvestidorContext>(
                dbContextOptions => dbContextOptions
                    .UseSqlServer(
                        configuration.GetConnectionString("db_Investidor"))
            );
            return services;
        }
    }
}
