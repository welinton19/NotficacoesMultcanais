namespace NotficacoesMulticanais.Domain.Services;

public interface IEmailService
{
    Task<bool> EnviarEmailAsync(string destinatario, string assunto, string corpo);
}
