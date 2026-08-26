using NotficacoesMulticanais.Application.InterfaceServices;
using NotficacoesMulticanais.Domain.Interface;

namespace NotficacoesMulticanais.Application.UseCases.Notificacoes;

public class ObterNotificacaoUseCase : IObterNotificacaoUseCase
{
    private readonly INotificacaoRepository _notificacaoRepository;

    public ObterNotificacaoUseCase(INotificacaoRepository notificacaoRepository)
    {
        _notificacaoRepository = notificacaoRepository;
    }

    public async Task<NotficacaoResponse?> ExecutarAsync(Guid id)
    {
        var notificacao = await _notificacaoRepository.ObterPorIdAsync(id);

        if (notificacao == null)
            return null; 

        return new NotficacaoResponse
        {
            Id = notificacao.Id,
            Destinatario = notificacao.Destinatario,
            Mensagem = notificacao.Mensagem,
            Assunto = notificacao.Assunto,
            Tipo = notificacao.Tipo,
            Status = notificacao.Status,      
            DataCriacao = notificacao.DataCriacao,  
            Sucesso = true                    
        };
    }
}
