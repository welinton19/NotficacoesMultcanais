using NotficacoesMultcanais.Domain.Enum;

namespace NotficacoesMulticanais.Domain.Entities;

public class ResultadoEnvio
{
    public bool Sucesso { get; set; }
    public string? MensagemErro { get; set; }
    public TipoNotificacao Canal { get; set; }
    public string? Destinatario { get; set; }
    public DateTime ProcessadoEm { get; set; }

    public ResultadoEnvio(bool sucesso, string? mensagemErro, TipoNotificacao canal, string? destinatario)
    {
        Sucesso = sucesso;
        MensagemErro = mensagemErro;
        Canal = canal;
        Destinatario = destinatario;
        ProcessadoEm = DateTime.UtcNow;
    }
}
