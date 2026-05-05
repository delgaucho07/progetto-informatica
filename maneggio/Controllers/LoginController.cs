using Microsoft.AspNetCore.Mvc;
using System.Linq;
using maneggio.data;
using maneggio.models;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly maneggioContext _context;

    public LoginController(maneggioContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Login([FromBody] Utente login)
    {
        var utente = _context.Utenti
            .FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);

        if (utente == null)
            return Unauthorized("Credenziali errate");

        return Ok(new { id = utente.Id, nome = utente.Nome });
    }
}
