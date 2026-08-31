using NotficacoesMulticanais.Application.UseCases.Notificacoes;

namespace NotficacoesMulticanais.Application.InterfaceServices;

public interface IObterNotificacaoUseCase
{
    Task<NotficacaoResponse?> ExecutarAsync(Guid id);
}
