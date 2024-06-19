using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Services.Slack;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Backend.Services.Midleware
{

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ISlackService _slackService;

    public ExceptionHandlingMiddleware(RequestDelegate next, ISlackService slackService)
    {
        _next = next;
        _slackService = slackService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            
            await _slackService.SendMessageAsync($"Ocurrió un error: {ex.Message}");

            
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync("Ocurrió un error en la aplicación. Por favor, inténtelo de nuevo más tarde.");
        }
    }
}
}