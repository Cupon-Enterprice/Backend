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
}
}