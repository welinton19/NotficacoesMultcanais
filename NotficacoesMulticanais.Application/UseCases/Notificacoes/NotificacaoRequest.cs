using NotficacoesMultcanais.Domain.Enum;

namespace NotficacoesMulticanais.Application.UseCases.Notificacoes;

public class NotificacaoRequest
{
    public string? Destinatario { get; set; }
    public string? Mensagem { get; set; }
    public string? Assunto { get; set; }
    public TipoNotificacao Tipo { get; set; }
    
}
