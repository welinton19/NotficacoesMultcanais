using NotficacoesMultcanais.Domain.Enum;

namespace NotficacoesMultcanais.Domain.Entities;

public class Notificacao
{
    public Guid Id { get; set; }
    public string? Destinatario { get; set; }
    public string? Mensagem { get; set; }
    public string? Assunto { get; set; }
    public TipoNotificacao Tipo { get; set; } 
    public StatusNotficacao Status { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataEnvio { get; set; }

    private Notificacao() { }

    public static Notificacao Criar(string destinatario, string mensagem, string assunto, TipoNotificacao tipo)
    {
        var notificacao = new Notificacao
        {
            Id = Guid.NewGuid(),
            Destinatario = destinatario,
            Mensagem = mensagem,
            Assunto = assunto,
            Tipo = tipo,
            Status = StatusNotficacao.Pendente,
            DataCriacao = DateTime.UtcNow
        };

        return notificacao;
    }
}
