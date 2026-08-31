using Microsoft.Extensions.Configuration;
using NotficacoesMulticanais.Domain.Services;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace NotficacoesMulticanais.Infraestructure.Services;

public class SmsService : ISmsService
{
    private readonly string _accountSid;
    private readonly string _authToken;
    private readonly string _fromNumber;

    public SmsService(IConfiguration configuration)
    {
        _accountSid = configuration["Twilio:AccountSid"]!;
        _authToken = configuration["Twilio:AuthToken"]!;
        _fromNumber = configuration["Twilio:FromNumber"]!;
    }

    public async Task<bool> EnviarSmsAsync(string destinatario, string mensagem)
    {
        TwilioClient.Init(_accountSid, _authToken);

        var message = await MessageResource.CreateAsync(
            body: mensagem,
            from: new Twilio.Types.PhoneNumber(_fromNumber),
            to: new Twilio.Types.PhoneNumber(destinatario)
        );

        return message.ErrorCode == null;
    }
}
