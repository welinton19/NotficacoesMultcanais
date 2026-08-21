using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using NotficacoesMulticanais.Infraestructure.DATA;
using Microsoft.EntityFrameworkCore;
using NotficacoesMulticanais.Domain.Interface;
using NotficacoesMulticanais.Infraestructure.Repository;


namespace NotficacoesMulticanais.Infraestructure.Injection;

public static class InjectionDependency
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {       
        
        services.AddDbContext<NotficacoesMulticanaisDbContext>(options => 
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                (b => b.MigrationsAssembly("NotficacoesMulticanais.Infraestructure")));
        });

        
         services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
         services.AddScoped<IResultadoEnvioRepository, ResultadoEnvioRepository>();

        return services;
    }
}
