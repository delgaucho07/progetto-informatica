
using Maneggio1.data;
using Maneggio1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Maneggio1.Services;

[ApiController]
[Route("api/[controller]")]
public class PrenotazioniController : ControllerBase
{
    private readonly maneggioContext _context;
    private readonly EmailService _emailService;

    public PrenotazioniController(maneggioContext context,
    EmailService emailService
)
    {
        _context = context;
        _emailService = emailService;
    }

    // PRENOTA
    [HttpPost]
public IActionResult Prenota(Prenotazione p)
{
    var user = _context.Utenti
        .FirstOrDefault(u => u.Id == p.IdUtente);

    if (user == null)
        return Unauthorized("Utente non autorizzato");

    p.Utente = null;

    _context.Prenotazioni.Add(p);

    _context.SaveChanges();

    // EMAIL
    _emailService.InviaPrenotazione(

        user.Email,

        p.Data.ToString(),

        p.Attivita,

        p.Cavallo
    );

    return Ok();
}

    // PRENOTAZIONI UTENTE
    [HttpGet("utente/{idUtente}")]
    public IActionResult GetPrenotazioniUtente(int idUtente)
    {
        var prenotazioni = _context.Prenotazioni
            .Where(p => p.IdUtente == idUtente)
            .ToList();

        return Ok(prenotazioni);
    }

    // TUTTE LE PRENOTAZIONI
    [HttpGet]
    public IActionResult GetTutte()
    {
        var prenotazioni = _context.Prenotazioni
            .Include(p => p.Utente)
            .ToList();

        return Ok(prenotazioni);
    }

    // ELIMINA PRENOTAZIONE
    [HttpDelete("{id}")]
    public IActionResult Elimina(int id)
    {
        var prenotazione = _context.Prenotazioni
            .FirstOrDefault(p => p.Id == id);

        if (prenotazione == null)
            return NotFound();

        _context.Prenotazioni.Remove(prenotazione);

        _context.SaveChanges();

        return Ok();
    }
}
