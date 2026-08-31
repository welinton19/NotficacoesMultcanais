using Microsoft.Extensions.Configuration;
using NotficacoesMulticanais.Domain.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace NotficacoesMulticanais.Infraestructure.Services;

public class EmailService : IEmailService
{
    private readonly string _apiKey;

    public EmailService(IConfiguration configuration)
    {
        _apiKey = configuration["SendGrid:ApiKey"]!;
    }

    public async Task<bool> EnviarEmailAsync(string destinatario, string assunto, string corpo)
    {
        var client = new SendGridClient(_apiKey);
        var msg = new SendGridMessage
        {
            From = new EmailAddress("batistawelinton54@gmail.com", "Notificações Multicanais"),
            Subject = assunto,
            PlainTextContent = corpo
        };
        msg.AddTo(new EmailAddress(destinatario));

        var response = await client.SendEmailAsync(msg);

        
        if (!response.IsSuccessStatusCode)
        {
            var body = await response.Body.ReadAsStringAsync();
            Console.WriteLine($"SendGrid erro: {response.StatusCode} - {body}");
        }

        return response.IsSuccessStatusCode;
    }
}
