using NotficacoesMultcanais.Domain.Entities;
using NotficacoesMultcanais.Domain.Enum;
using NotficacoesMulticanais.Domain.Entities;
using NotficacoesMulticanais.Domain.Services;

namespace NotficacoesMulticanais.Domain.Validators;

public class WhatsAppValidator : INotficacoesService
{
    public TipoNotificacao Notificacao => TipoNotificacao.WhatsApp;
    public ResultadoEnvio Status(Notificacao notificacao)
    {
        var telefone = notificacao.Destinatario?.Replace(" ", "").Replace("-", "")
                                              .Replace("(", "").Replace(")", "")
                                              .Replace("+", "").Trim();

        if (string.IsNullOrWhiteSpace(telefone))
            return ResultadoEnvio.Criar(false, "Número de WhatsApp não informado.", TipoNotificacao.WhatsApp, notificacao.Destinatario);

        if (!telefone.All(char.IsDigit))
            return ResultadoEnvio.Criar(false, "WhatsApp deve conter apenas números.", TipoNotificacao.WhatsApp, notificacao.Destinatario);

        if (telefone.Length < 10 || telefone.Length > 13)
            return ResultadoEnvio.Criar(false, "Número de WhatsApp inválido. Use DDD + número.", TipoNotificacao.WhatsApp, notificacao.Destinatario);

        return ResultadoEnvio.Criar(true, "WhatsApp válido.", TipoNotificacao.WhatsApp, notificacao.Destinatario);
    }
}

