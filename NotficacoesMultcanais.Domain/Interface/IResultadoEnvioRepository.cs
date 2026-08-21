using NotficacoesMulticanais.Domain.Entities;

namespace NotficacoesMulticanais.Domain.Interface;

public interface IResultadoEnvioRepository
{
    Task<IEnumerable<ResultadoEnvio>> ObterTodosAsync();
    Task AdicionarAsync(ResultadoEnvio resultadoEnvio);
}
