using Microsoft.EntityFrameworkCore;
using NotficacoesMultcanais.Domain.Entities;
using NotficacoesMulticanais.Domain.Entities;

namespace NotficacoesMulticanais.Infraestructure.DATA;

public class NotficacoesMulticanaisDbContext : DbContext
{
    public NotficacoesMulticanaisDbContext(DbContextOptions<NotficacoesMulticanaisDbContext> options) : base(options)
    {
    }
    public DbSet<Notificacao> Notificacoes { get; set; }
    public DbSet<ResultadoEnvio> ResultadosEnvio { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotficacoesMulticanaisDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
