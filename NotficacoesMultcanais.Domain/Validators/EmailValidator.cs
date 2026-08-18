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
        
        return new ResultadoEnvio(true, null, TipoNotificacao.Email, notificacao.Destinatario);
    }
}
