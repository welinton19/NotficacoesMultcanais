using Microsoft.EntityFrameworkCore;
using NotficacoesMultcanais.Domain.Entities;

namespace NotficacoesMulticanais.Infraestructure.EntitiesConfiguration;

public class NotificacaoConfiguration : IEntityTypeConfiguration<Notificacao>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Notificacao> builder)
    {
        builder.HasKey(n => n.Id);
        builder.Property(n => n.Destinatario)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(n => n.Mensagem)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(n => n.Assunto)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(n => n.Tipo)
            .HasConversion<string>();

        builder.Property(n => n.Status)
            .HasConversion<string>();

        builder.Property(n => n.DataCriacao).Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

        builder.Property(n => n.DataEnvio).Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
    }
}
