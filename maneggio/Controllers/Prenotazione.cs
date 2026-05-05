using maneggio.data;
using maneggio.models;
using maneggio.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PrenotazioniController : ControllerBase
{
    private readonly maneggioContext _Context;
    private readonly EmailService _emailService;

    public PrenotazioniController(maneggioContext Context, EmailService emailService)
    {
        _Context = Context;
        _emailService = emailService;
    }


    [HttpGet("tutte")]
    public IActionResult GetTutte(string ruolo)
    {
        if (ruolo != "admin")
            return BadRequest();

        return Ok(_Context.Prenotazioni.Include(p => p.Utente).ToList());
    }

    [HttpGet("mie")]
    public IActionResult GetMie(string username)
    {
        return Ok(
            _Context.Prenotazioni
            .Include(p => p.Utente)
            .Where(p => p.Utente.Username == username)
            .ToList()
        );
    }

    [HttpPost]
    public IActionResult Prenota(Prenotazione p)
    {
        var esiste = _Context.Prenotazioni.Any(x => x.Data == p.Data);

        if (esiste)
            return BadRequest("Orario gia prenotato");

        _Context.Prenotazioni.Add(p);
        _Context.SaveChanges();

        //  INVIO EMAIL DOPO SALVATAGGIO
        _emailService.InviaConfermaPrenotazione(
            p.Utente.Email,     // oppure p.Email se ce l’hai nel modello
            p.Data.ToString()
        );

        return Ok(p)

        if (p.IdUtente == 0)
        _Context.Prenotazioni.Add(p);
        _Context.SaveChanges();
        return Ok();
    }
    
    [HttpGet("{idUtente}")]
public IActionResult GetPrenotazioni(int idUtente)
{
    var prenotazioni = _context.Prenotazioni
        .Where(p => p.IdUtente == idUtente)
        .ToList();

    return Ok(prenotazioni);
}
}
