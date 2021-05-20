using API_Investidor.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Configurations
{
    public static class ApiServicesConfiguration
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            //   services.Configure<Class>(configuration.GetSection("Class"));
            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<ICategoriasService, CategoriasService>();
            services.AddTransient<IClientesService, ClientesService>();
            services.AddTransient<IArtigosService, ArtigosService>();
            services.AddTransient<IEBooksService, EBooksService>();
            services.AddTransient<ILivesService, LivesService>();

            return services;
        }
    }
}
