using NotficacoesMultcanais.Domain.Entities;
using NotficacoesMultcanais.Domain.Enum;
using NotficacoesMulticanais.Domain.Entities;
using NotficacoesMulticanais.Domain.Services;

namespace NotficacoesMulticanais.Domain.Validators;

public class EmailValidator : INotficacoesService
{
   

    public TipoNotificacao Notificacao => TipoNotificacao.Email;

    public ResultadoEnvio Status(Notificacao notificacao)
    {
        var email = notificacao.Destinatario.Trim();

        if (string.IsNullOrWhiteSpace(email))
            return ResultadoEnvio.Criar(false, "Formato de E-mail Inválido! ", TipoNotificacao.Email, notificacao.Destinatario);


        if (!email.Contains('@') || !email.Contains('.'))
            return ResultadoEnvio.Criar(false, "Formato de E-mail Inválido! ", TipoNotificacao.Email, notificacao.Destinatario);

        var partes = email.Split('@');
        if (partes.Length != 2 || string.IsNullOrWhiteSpace(partes[0]) || string.IsNullOrWhiteSpace(partes[1]))
            return ResultadoEnvio.Criar(false, "Formato de e-mail inválido.", TipoNotificacao.Email, notificacao.Destinatario);





        return ResultadoEnvio.Criar(true, "E-mail válido.", TipoNotificacao.Email, notificacao.Destinatario);
    }
}
