
using Maneggio1.data;
using Maneggio1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PrenotazioniController : ControllerBase
{
    private readonly maneggioContext _context;

    public PrenotazioniController(maneggioContext context)
    {
        _context = context;
    }

    // PRENOTA
    [HttpPost]
    public IActionResult Prenota(Prenotazione p)
    {
        // Controllo utente
        var user = _context.Utenti
            .FirstOrDefault(u => u.Id == p.IdUtente);

        if (user == null)
            return Unauthorized("Utente non trovato");

        // Controllo orario occupato
        bool occupato = _context.Prenotazioni
            .Any(x => x.Data == p.Data);

        if (occupato)
            return BadRequest("Orario già prenotato");

        // Salva prenotazione
        _context.Prenotazioni.Add(p);

        _context.SaveChanges();

        return Ok(new
        {
            message = "Prenotazione effettuata"
        });
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
