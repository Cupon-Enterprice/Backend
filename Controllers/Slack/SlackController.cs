using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Services.Slack;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Slack
{
[ApiController]
[Route("api/[controller]")]
public class SlackController : ControllerBase
{
    private readonly ISlackService _slackService;

    public SlackController(ISlackService slackService)
    {
        _slackService = slackService;
    }

    [HttpPost]
    public async Task<IActionResult> PostMessage([FromBody] string message)
    {
        await _slackService.SendMessageAsync(message);
        return Ok(new { success = true });
    }

    [HttpGet]
    [Route("generate-exception")]
    public async Task<IActionResult> GenerateException()
    {
        try
        {
            // Generar una excepción de prueba
            throw new InvalidOperationException("This is a test exception.");
        }
        catch (Exception ex)
        {
            // Enviar detalles de la excepción a Slack
            await _slackService.SendMessageAsync($"se ha generado una excepcion {ex}");

            // Retornar la excepción al cliente
            return StatusCode(500, new { error = ex.Message });
        }
    }
}
}