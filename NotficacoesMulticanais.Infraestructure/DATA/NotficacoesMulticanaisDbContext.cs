using Microsoft.EntityFrameworkCore;
using NotficacoesMultcanais.Domain.Entities;
using NotficacoesMulticanais.Domain.Entities;

namespace NotficacoesMulticanais.Infraestructure.DATA;

public class NotificacoesMulticanaisDbContext : DbContext
{
    public NotificacoesMulticanaisDbContext(DbContextOptions<NotificacoesMulticanaisDbContext> options) : base(options)
    {
    }

    public DbSet<Notificacao> Notificacoes { get; set; }
    public DbSet<ResultadoEnvio> ResultadosEnvio { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificacoesMulticanaisDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
