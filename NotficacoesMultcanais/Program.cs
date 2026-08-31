using NotficacoesMulticanais.Application.InterfaceServices;
using NotficacoesMulticanais.Application.Services;
using NotficacoesMulticanais.Application.UseCases.Notificacoes;
using NotficacoesMulticanais.Infraestructure.Injection;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


//Injection of services
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<IEnviarNotificacaoUseCase,NotificacaoService>();
builder.Services.AddScoped<IObterNotificacaoUseCase,NotificacaoService>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options.Title = "NotificacoesMultcanais API";
    options.Theme = ScalarTheme.DeepSpace;
});

//app.UseCors("AllowAll");
app.UseHttpsRedirection();


app.MapControllers();



app.Run();


