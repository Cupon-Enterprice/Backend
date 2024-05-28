using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/Login")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult TokenValido()
    {
        return Ok(new { message = "Acesso Concedido" });
    }
}
