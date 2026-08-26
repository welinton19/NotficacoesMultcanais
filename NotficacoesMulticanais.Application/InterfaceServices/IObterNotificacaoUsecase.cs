using NotficacoesMulticanais.Application.UseCases.Notificacoes;

namespace NotficacoesMulticanais.Application.InterfaceServices;

public interface IObterNotificacaoUsecase
{
    Task<NotficacaoResponse> ExecutarAsync(Guid id);
}
