using NotficacoesMultcanais.Domain.Entities;
using NotficacoesMulticanais.Application.InterfaceServices;
using NotficacoesMulticanais.Application.UseCases.Notificacoes;
using NotficacoesMulticanais.Domain.Interface;

namespace NotficacoesMulticanais.Application.Services;

public class NotificacaoService : EnviarNotificacaoUseCase, IObterNotificacaoUseCase
{
    private readonly INotificacaoRepository _notificacaoRepository;

    
    public NotificacaoService(INotificacaoRepository notificacaoRepository)
        : base(notificacaoRepository) => _notificacaoRepository = notificacaoRepository;
    

    public async Task<NotficacaoResponse> ExecutarAsync(NotificacaoRequest request)
    {
        var notificacao = Notificacao.Criar(
            request.Destinatario!,
            request.Mensagem!,
            request.Assunto,
            request.Tipo
        );

        await _notificacaoRepository.AdicionarAsync(notificacao);

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
