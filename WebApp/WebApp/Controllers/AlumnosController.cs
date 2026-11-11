 using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapp.Models;
using WebApp.Models;

[Route("api/[controller]")]
[ApiController]
public class AlumnosController : ControllerBase
{
    private readonly MyDbContext _context;
    public AlumnosController(MyDbContext context)
    {
        _context = context;
    }

    // GET: api/alumnos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<alumnos>>> Getalumnos()
    {
        return await _context.Alumnos.ToListAsync();
    }

    // GET: api/Alumno/buscar
    [HttpGet("buscar")]
    public async Task<ActionResult<IEnumerable<alumnos>>> BuscarAlumno([FromQuery]AlumnoBusquedaParametros parametros)
    {
        var consulta = _context.Alumnos.AsQueryable();
        if (!string.IsNullOrEmpty(parametros.buscar))
        {
            consulta = consulta.Where(alumno => alumno.nombre.Contains(parametros.buscar));
        }
        return await consulta.ToListAsync();
    }


    // GET: api/alumnos/5
    [HttpGet("{idalumno}")]
    public async Task<ActionResult<alumnos>> Getalumnos(int idalumno)
    {
        var alumnos = await _context.Alumnos.FindAsync(idalumno);

        if (alumnos == null)
        {
            return NotFound();
        }

        return alumnos;
    }

    // PUT: api/alumnos/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idalumno}")]
    public async Task<IActionResult> Putalumnos(int? idalumno, alumnos alumnos)
    {
        if (idalumno != alumnos.idAlumno)
        {
            return BadRequest();
        }

        _context.Entry(alumnos).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!alumnosExists(idalumno))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/alumnos
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<alumnos>> Postalumnos(alumnos alumnos)
    {
        _context.Alumnos.Add(alumnos);
        await _context.SaveChangesAsync();

        return CreatedAtAction("Getalumnos", new { idalumno = alumnos.idAlumno }, alumnos);
    }

    // DELETE: api/alumnos/5
    [HttpDelete("{idalumno}")]
    public async Task<IActionResult> Deletealumnos(int? idalumno)
    {
        var alumnos = await _context.Alumnos.FindAsync(idalumno);
        if (alumnos == null)
        {
            return NotFound();
        }

        _context.Alumnos.Remove(alumnos);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool alumnosExists(int? idalumno)
    {
        return _context.Alumnos.Any(e => e.idAlumno == idalumno);
    }
}
