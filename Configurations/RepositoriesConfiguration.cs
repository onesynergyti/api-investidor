using API_Investidor.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Configurations
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICategoriasRepository, CategoriasRepository>();
            services.AddTransient<IClientesRepository, ClientesRepository>();
            services.AddTransient<IArtigosRepository, ArtigosRepository>();
            services.AddTransient<IEBooksRepository, EBooksRepository>();
            services.AddTransient<ILivesRepository, LivesRepository>();

            return services;
        }
    }
}
