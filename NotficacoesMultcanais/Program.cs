using NotficacoesMulticanais.Infraestructure.Injection;

var builder = WebApplication.CreateBuilder(args);



//Injection of services
builder.Services.AddInfrastructure(builder.Configuration);



builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
        {
    app.MapOpenApi();
        }

app.UseHttpsRedirection();



app.Run();


