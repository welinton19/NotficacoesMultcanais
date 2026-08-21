using NotficacoesMultcanais.Domain.Entities;
using NotficacoesMultcanais.Domain.Enum;
using NotficacoesMulticanais.Domain.Entities;
using NotficacoesMulticanais.Domain.Services;

namespace NotficacoesMulticanais.Domain.Validators;

public class SmsValidator : INotficacoesService
{
    public TipoNotificacao Notificacao => TipoNotificacao.Sms;

    public ResultadoEnvio Status(Notificacao notificacao)
    {
        var telefone = notificacao.Destinatario?.Replace(" ", "").Replace("-", "")
                                               .Replace("(", "").Replace(")", "").Trim();

        if (string.IsNullOrWhiteSpace(telefone))
            return ResultadoEnvio.Criar(false, "Número de telefone não informado.", TipoNotificacao.Sms, notificacao.Destinatario);

        if (!telefone.All(char.IsDigit))
            return ResultadoEnvio.Criar(false, "Telefone deve conter apenas números.", TipoNotificacao.Sms, notificacao.Destinatario);

        if (telefone.Length < 10 || telefone.Length > 13)
            return ResultadoEnvio.Criar(false, "Telefone inválido. Use DDD + número.", TipoNotificacao.Sms, notificacao.Destinatario);

        return ResultadoEnvio.Criar(true, "Telefone válido.", TipoNotificacao.Sms, notificacao.Destinatario);
    }
}

