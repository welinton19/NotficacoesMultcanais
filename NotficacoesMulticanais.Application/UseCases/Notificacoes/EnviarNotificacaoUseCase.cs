using NotficacoesMultcanais.Domain.Entities;

using NotficacoesMulticanais.Application.InterfaceServices;
using NotficacoesMulticanais.Domain.Interface;

namespace NotficacoesMulticanais.Application.UseCases.Notificacoes;

public class EnviarNotificacaoUseCase : IEnviarNotficacaoUseCase
{
    private readonly INotificacaoRepository _notificacaoRepository;

    public EnviarNotificacaoUseCase(INotificacaoRepository notificacaoRepository)
    {
        _notificacaoRepository = notificacaoRepository;
    }

    public async Task<NotficacaoResponse> EnviarNotificacaoAsync(NotificacaoRequest request)
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

    
}