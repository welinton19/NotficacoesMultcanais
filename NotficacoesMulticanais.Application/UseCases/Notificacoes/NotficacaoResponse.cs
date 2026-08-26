using NotficacoesMultcanais.Domain.Enum;

namespace NotficacoesMulticanais.Application.UseCases.Notificacoes;

public class NotficacaoResponse
{
    public Guid Id { get; set; }
    public string? Destinatario { get; set; }
    public string? Mensagem { get; set; }
    public string? Assunto { get; set; }
    public TipoNotificacao Tipo { get; set; }
    public StatusNotficacao Status { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataEnvio { get; set; }
    public bool Sucesso { get; set; }
    public string? MensagemErro { get; set; }
}
