using API_Investidor.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace API_Investidor.Configurations
{
    public static class ApiServicesConfiguration
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddTransient<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<ICategoriasService, CategoriasService>();
            services.AddTransient<IClientesService, ClientesService>();
            services.AddTransient<IArtigosService, ArtigosService>();
            services.AddTransient<IEBooksService, EBooksService>();
            services.AddTransient<ILivesService, LivesService>();
            services.AddTransient<IZenviaService, ZenviaService>();
            services.AddTransient<ISMTPService, SMTPService>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<ITokensService, TokensService>();
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IGruposService, GruposService>();
            services.AddTransient<IParceirosService, ParceirosService>();
            services.AddTransient<IGrupoClienteService, GrupoClienteService>();

            return services;
        }
    }
}
