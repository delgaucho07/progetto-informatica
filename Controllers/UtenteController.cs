
using Maneggio1.data;
using Maneggio1.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UtentiController : ControllerBase
{
    private readonly maneggioContext _context;

    public UtentiController(maneggioContext context)
    {
        _context = context;
    }
}
