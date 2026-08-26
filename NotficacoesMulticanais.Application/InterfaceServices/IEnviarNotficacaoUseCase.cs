using NotficacoesMulticanais.Application.UseCases.Notificacoes;

namespace NotficacoesMulticanais.Application.InterfaceServices;

public interface IEnviarNotficacaoUseCase
{
    Task<NotficacaoResponse> ExecutarAsync(NotificacaoRequest request);
}
