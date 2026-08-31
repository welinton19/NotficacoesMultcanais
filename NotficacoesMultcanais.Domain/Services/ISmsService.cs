namespace NotficacoesMulticanais.Domain.Services;

public interface ISmsService
{
    Task<bool> EnviarSmsAsync(string destinatario, string mensagem);
}
