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
    private readonly ISlackNotificationService _slackService;

    public SlackController(ISlackNotificationService slackService)
    {
        _slackService = slackService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendSlackNotification()
    {
        try
        {
            // Ejemplo de envío de notificación
            await _slackService.SendNotificationAsync("Esta es una prueba de notificación a Slack desde ASP.NET Core");

            return Ok("Notificación enviada exitosamente");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al enviar notificación: {ex.Message}");
        }
    }
}
}