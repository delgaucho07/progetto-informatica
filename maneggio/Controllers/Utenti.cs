using Microsoft.AspNetCore.Mvc;
using maneggio.data;
using maneggio.models;

[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login(Utente login)
    {
        var user =maneggioContext.Utenti.FirstOrDefault(u => u.Username==login.Username);
        if (user == null)
            return Unauthorized();
         bool valida =BCrypt.Net.BCrypt.Verify(login.Password,user.Password);
        if (!valida)
            return Unauthorized();
        return Ok(new
        {
            user.Id,
            user.Username,
            user.Ruolo

        });
    }
        
}
