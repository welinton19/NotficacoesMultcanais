using NotficacoesMulticanais.Domain.Entities;
using NotficacoesMulticanais.Domain.Interface;
using NotficacoesMulticanais.Infraestructure.DATA;
using Microsoft.EntityFrameworkCore;

namespace NotficacoesMulticanais.Infraestructure.Repository;

public class ResultadoEnvioRepository : IResultadoEnvioRepository
{
    private readonly NotficacoesMulticanaisDbContext _context;

    public ResultadoEnvioRepository(NotficacoesMulticanaisDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(ResultadoEnvio resultadoEnvio)
    {
        await _context.ResultadosEnvio.AddAsync(resultadoEnvio);
        await _context.SaveChangesAsync();
    }

    public async  Task<IEnumerable<ResultadoEnvio>> ObterTodosAsync() =>  await _context.ResultadosEnvio.ToListAsync();
    
}
