using NotficacoesMultcanais.Domain.Entities;

namespace NotficacoesMulticanais.Domain.Interface;

public interface INotificacaoRepository
{

    Task<Notificacao?> ObterPorIdAsync(Guid id);
    Task<IEnumerable<Notificacao>> ObterTodosAsync();
    Task AdicionarAsync(Notificacao notificacao);
    Task AtualizarAsync(Notificacao notificacao);
}
