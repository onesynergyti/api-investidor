using Microsoft.Extensions.DependencyInjection;

namespace API_Investidor.Configurations
{
    public static class CorsConfiguration
    {
        public static IServiceCollection AddApiCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "_myAllowSpecificOrigins",
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                          .AllowAnyHeader()
                                          .AllowAnyMethod();
                                  });
            });

            return services;
        }
    }
}
