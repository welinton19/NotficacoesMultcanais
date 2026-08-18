using NotficacoesMultcanais.Domain.Entities;
using NotficacoesMultcanais.Domain.Enum;
using NotficacoesMulticanais.Domain.Entities;

namespace NotficacoesMulticanais.Domain.Services;

public interface INotficacoesService
{
    TipoNotificacao Notificacao { get; }
    ResultadoEnvio Status (Notificacao notificacao);
}
}
