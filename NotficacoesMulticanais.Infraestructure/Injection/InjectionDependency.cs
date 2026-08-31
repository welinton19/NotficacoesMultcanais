using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using NotficacoesMulticanais.Infraestructure.DATA;
using Microsoft.EntityFrameworkCore;
using NotficacoesMulticanais.Domain.Interface;
using NotficacoesMulticanais.Infraestructure.Repository;
using NotficacoesMulticanais.Infraestructure.Services;
using NotficacoesMulticanais.Domain.Services;



namespace NotficacoesMulticanais.Infraestructure.Injection;

public static class InjectionDependency
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<NotificacoesMulticanaisDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("NotificacoesConnection"),
                b => b.MigrationsAssembly("NotficacoesMulticanais.Infraestructure"));
        });


        services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
        services.AddScoped<IResultadoEnvioRepository, ResultadoEnvioRepository>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<ISmsService, SmsService>();
        services.AddHttpClient<IWhatsAppService, WhatsAppService>();



        return services;
    }
}
