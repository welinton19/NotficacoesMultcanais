namespace NotficacoesMulticanais.Domain.Services;

public interface IWhatsAppService
{
    Task<bool> EnviarWhatsAppAsync(string destinatario, string mensagem);
}
