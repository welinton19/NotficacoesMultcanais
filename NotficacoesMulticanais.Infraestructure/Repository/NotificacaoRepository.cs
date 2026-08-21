using NotficacoesMultcanais.Domain.Entities;
using NotficacoesMulticanais.Domain.Interface;
using NotficacoesMulticanais.Infraestructure.DATA;
using Microsoft.EntityFrameworkCore;

namespace NotficacoesMulticanais.Infraestructure.Repository;

public class NotificacaoRepository : INotificacaoRepository
{
    private readonly NotficacoesMulticanaisDbContext _context;

    public NotificacaoRepository(NotficacoesMulticanaisDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Notificacao notificacao)
    {
       

        await _context.Notificacoes.AddAsync(notificacao);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Notificacao notificacao)
    {
        

        _context.Notificacoes.Update(notificacao);
        await _context.SaveChangesAsync();
    }

    public async Task<Notificacao?> ObterPorIdAsync(Guid id) => await _context.Notificacoes.FindAsync(id);

    public async Task<IEnumerable<Notificacao>> ObterTodosAsync() => await _context.Notificacoes.ToListAsync();
}
    

