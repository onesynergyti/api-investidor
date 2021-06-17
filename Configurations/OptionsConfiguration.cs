using API_Investidor.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Configurations
{
    public static class OptionsConfiguration
    {
        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ZenviaOptions>(configuration.GetSection("ZenviaOptions"));
            services.Configure<EmailOptions>(configuration.GetSection("EmailOptions"));
            services.Configure<NotificationHubOptions>(configuration.GetSection("NotificationHubOptions"));

            return services;
        }
    }
}