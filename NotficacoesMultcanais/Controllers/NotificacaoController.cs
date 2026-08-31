using Microsoft.AspNetCore.Mvc;
using NotficacoesMulticanais.Application.InterfaceServices;
using NotficacoesMulticanais.Application.Services;
using NotficacoesMulticanais.Application.UseCases.Notificacoes;

namespace NotficacoesMultcanais.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificacaoController : ControllerBase
{
    private readonly ILogger<NotificacaoController> _logger;
    private readonly IEnviarNotificacaoUseCase _enviarUseCase;
    private readonly IObterNotificacaoUseCase _obterUseCase;

    public NotificacaoController(
        ILogger<NotificacaoController> logger,
        IEnviarNotificacaoUseCase enviarUseCase,   
        IObterNotificacaoUseCase obterUseCase)     
    {
        _logger = logger;
        _enviarUseCase = enviarUseCase;
        _obterUseCase = obterUseCase;
    }

    [HttpPost("enviar")]
    public async Task<IActionResult> EnviarNotificacao([FromBody] NotificacaoRequest request)
    {
        try
        {
            var resultado = await _enviarUseCase.ExecutarAsync(request);
            return Ok(resultado);  
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao enviar notificação.");
            return StatusCode(500, "Erro interno do servidor.");
        }
    }

    [HttpGet("status/{id}")]
    public async Task<IActionResult> ObterStatusNotificacao(Guid id)
    {
        try
        {
            var status = await _obterUseCase.ExecutarAsync(id);
            if (status == null)
                return NotFound();

            return Ok(status);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter status da notificação.");
            return StatusCode(500, "Erro interno do servidor.");
        }
    }
}
