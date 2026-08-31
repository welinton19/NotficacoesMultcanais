using NotficacoesMultcanais.Domain.Entities;
using NotficacoesMultcanais.Domain.Enum;
using NotficacoesMulticanais.Application.InterfaceServices;
using NotficacoesMulticanais.Application.UseCases.Notificacoes;
using NotficacoesMulticanais.Domain.Interface;
using NotficacoesMulticanais.Domain.Services;

namespace NotficacoesMulticanais.Application.Services;

public class NotificacaoService : IEnviarNotificacaoUseCase, IObterNotificacaoUseCase
{
    private readonly INotificacaoRepository _notificacaoRepository;
    private readonly IEmailService _emailService;
    private readonly ISmsService _smsService;
    private readonly IWhatsAppService _whatsAppService;

    public NotificacaoService(
        INotificacaoRepository notificacaoRepository,
        IEmailService emailService,
        ISmsService smsService,
        IWhatsAppService whatsAppService)
    {
        _notificacaoRepository = notificacaoRepository;
        _emailService = emailService;
        _smsService = smsService;
        _whatsAppService = whatsAppService;
    }

    public async Task<NotficacaoResponse> ExecutarAsync(NotificacaoRequest request)
    {
        Console.WriteLine($"Tipo recebido: {request.Tipo} - Valor: {(int)request.Tipo}");

        var notificacao = Notificacao.Criar(
            request.Destinatario!,
            request.Mensagem!,
            request.Assunto,
            request.Tipo
        );

        Console.WriteLine($"Chamando service para: {request.Tipo}");

        
        var sucesso = request.Tipo switch
        {
            TipoNotificacao.Email => await _emailService.EnviarEmailAsync(
                request.Destinatario!,
                request.Assunto ?? "Notificação",
                request.Mensagem!),

            TipoNotificacao.Sms => await _smsService.EnviarSmsAsync(
                request.Destinatario!,
                request.Mensagem!),

            TipoNotificacao.WhatsApp => await _whatsAppService.EnviarWhatsAppAsync(
                request.Destinatario!,
                request.Mensagem!),

            _ => throw new Exception("Tipo de notificação não suportado.")
        };

        
        notificacao.AtualizarStatus(sucesso
            ? StatusNotficacao.Enviado
            : StatusNotficacao.Falhou);

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
            Sucesso = sucesso,
            MensagemErro = sucesso ? null : "Falha ao enviar notificação."
        };


    }

    public async Task<NotficacaoResponse?> ExecutarAsync(Guid id)
    {
        var notificacao = await _notificacaoRepository.ObterPorIdAsync(id);

        if(notificacao == null)
        {
            return null;
        }

        return new NotficacaoResponse
        {
            Id = notificacao.Id,
            Destinatario = notificacao.Destinatario,
            Mensagem = notificacao.Mensagem,
            Assunto = notificacao.Assunto,
            Tipo = notificacao.Tipo,
            Status = notificacao.Status,
            DataCriacao = notificacao.DataCriacao,
            DataEnvio = notificacao.DataEnvio,
            Sucesso = notificacao.Status == StatusNotficacao.Enviado,
            MensagemErro = notificacao.Status == StatusNotficacao.Falhou ? "Falha ao enviar notificação." : null
        };
    }
}
