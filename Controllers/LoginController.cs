using Maneggio1.data;
using Maneggio1.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly maneggioContext _context;

    public AuthController(maneggioContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login(Login login)
    {
        var user = _context.Utenti
            .FirstOrDefault(u => u.Username == login.Username);

        if (user == null)
            return Unauthorized("Username non trovato");

        // SENZA CRYPTO: confronto diretto
        if (user.Password != login.Password)
            return Unauthorized("Password errata");

        return Ok(new
        {
            user.Id,
            user.Username,
            user.Ruolo
        });
    }
}
