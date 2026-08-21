using NotficacoesMultcanais.Domain.Enum;

namespace NotficacoesMulticanais.Domain.Entities;

public class ResultadoEnvio
{
    public bool Sucesso { get; set; }
    public string? MensagemErro { get; set; }
    public TipoNotificacao Canal { get; set; }
    public string? Destinatario { get; set; }
    public DateTime ProcessadoEm { get; set; }

    public static ResultadoEnvio Criar(bool sucesso, string? mensagemErro, TipoNotificacao canal, string? destinatario)
    {
        var resultado = new ResultadoEnvio
        {
            Sucesso = sucesso,
            MensagemErro = mensagemErro,
            Canal = canal,
            Destinatario = destinatario
        };

        return resultado;
    }
}

