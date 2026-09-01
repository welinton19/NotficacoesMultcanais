FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["NotficacoesMultcanais/NotficacoesMultcanais.csproj", "NotficacoesMultcanais/"]
COPY ["NotficacoesMulticanais.Application/NotficacoesMulticanais.Application.csproj", "NotficacoesMulticanais.Application/"]
COPY ["NotficacoesMultcanais.Domain/NotficacoesMulticanais.Domain.csproj", "NotficacoesMulticanais.Domain/"]
COPY ["NotficacoesMulticanais.Infraestructure/NotficacoesMulticanais.Infraestructure.csproj", "NotficacoesMulticanais.Infraestructure/"]
RUN dotnet restore "NotficacoesMultcanais/NotficacoesMultcanais.csproj"
COPY . .
WORKDIR "/src/NotficacoesMultcanais"
RUN dotnet build "NotficacoesMultcanais.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NotficacoesMultcanais.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NotficacoesMultcanais.dll"]