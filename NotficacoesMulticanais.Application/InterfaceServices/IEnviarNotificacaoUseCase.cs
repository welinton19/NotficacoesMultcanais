using NotficacoesMulticanais.Application.UseCases.Notificacoes;

namespace NotficacoesMulticanais.Application.InterfaceServices;

public interface IEnviarNotificacaoUseCase
{
    Task<NotficacaoResponse> ExecutarAsync(NotificacaoRequest request);
}
