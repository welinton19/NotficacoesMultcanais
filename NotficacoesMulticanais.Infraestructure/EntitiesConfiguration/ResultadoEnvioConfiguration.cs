using Microsoft.EntityFrameworkCore;
using NotficacoesMulticanais.Domain.Entities;

namespace NotficacoesMulticanais.Infraestructure.EntitiesConfiguration;

public class ResultadoEnvioConfiguration : IEntityTypeConfiguration<ResultadoEnvio>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ResultadoEnvio> builder)
    {
        builder.HasKey(r => r.Destinatario);
        builder.Property(r => r.Sucesso)
            .IsRequired();
        builder.Property(r => r.MensagemErro)
            .HasMaxLength(1000);
        builder.Property(r => r.Canal)
            .HasConversion<string>();
        builder.Property(r => r.ProcessadoEm)
            .IsRequired();
    }
}
