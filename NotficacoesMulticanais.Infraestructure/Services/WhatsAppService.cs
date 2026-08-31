using Microsoft.Extensions.Configuration;
using NotficacoesMulticanais.Domain.Services;
using System.Text;
using System.Text.Json;

namespace NotficacoesMulticanais.Infraestructure.Services;

public class WhatsAppService : IWhatsAppService
{
    private readonly string _instanceId;
    private readonly string _token;
    private readonly HttpClient _httpClient;
    private readonly string _clientToken;

    public WhatsAppService(IConfiguration configuration, HttpClient httpClient)
    {
        _instanceId = configuration["ZApi:InstanceId"]!;
        _token = configuration["ZApi:Token"]!;
        _clientToken = configuration["ZApi:ClientToken"]!;
        _httpClient = httpClient;
        
    }

    public async Task<bool> EnviarWhatsAppAsync(string destinatario, string mensagem)
    {
        try
        {
            var telefone = destinatario.Replace("+", "").Replace("-", "").Replace(" ", "").Trim();
            var url = $"https://api.z-api.io/instances/{_instanceId}/token/{_token}/send-text";

            var payload = new { phone = telefone, message = mensagem };
            var json = JsonSerializer.Serialize(payload);

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Client-Token", _clientToken); // ← aqui

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            var body = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status: {response.StatusCode}");
            Console.WriteLine($"Response: {body}");

            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exceção: {ex.Message}");
            return false;
        }
    }
}