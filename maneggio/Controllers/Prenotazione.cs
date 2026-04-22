using maneggio;
using maneggio.data;
using maneggio.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[ApiController]
[Route("api/[controller]")]
public class PrenotazioniController : ControllerBase
 {
    private readonly maneggioContext _Context;
    public PrenotazioniController(maneggioContext Context)
    {
       _Context = Context;
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
        return Ok(_Context.Prenotazioni.Include(p => p.Utente).Where(p =>p.Utente.Username == username).ToList());
    }
    [HttpPost]
    public IActionResult
        Prenota(Prenotazione p)
    {
        var esiste =_Context.Prenotazioni.Any(x =>x.Data== p.Data);
        if (esiste)
            return BadRequest("Orario gia prenotato");
        _Context.Prenotazioni.Add(p);
        _Context.SaveChanges();
        return Ok(p);
    }
}
