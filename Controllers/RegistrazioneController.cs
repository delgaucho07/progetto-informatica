using Maneggio1.data;
using Maneggio1.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RegistrazioneController : ControllerBase
{
    private readonly maneggioContext _context;

    public RegistrazioneController(maneggioContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Register(Utenti u)
    {
        var esiste = _context.Utenti
            .Any(x => x.Username == u.Username);

        if (esiste)
            return BadRequest("Username già esistente");

        _context.Utenti.Add(u);

        _context.SaveChanges();

        return Ok(new
        {
            message = "Registrazione completata"
        });
    }
}
