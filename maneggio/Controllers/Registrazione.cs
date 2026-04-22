using Microsoft.AspNetCore.Mvc;
using maneggio.data;
using maneggio.models;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly maneggioContext maneggioContext;
    public AuthController(maneggioContext context)
    {
        maneggioContext = context;
    }
    [HttpPost("register")]
    public IActionResult Register(Utente u)
    {
        u.Password = BCrypt.Net.BCrypt.HashPassword(u.Password);
        u.Ruolo = "Utente";

        maneggioContext.Utenti.Add(u);
        maneggioContext.SaveChanges();

        return Ok(u);
    }
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
