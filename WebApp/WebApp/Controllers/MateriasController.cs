using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

[Route("api/[controller]")]
[ApiController]
public class MateriasController : ControllerBase
{
    private readonly MyDbContext _context;
    public MateriasController(MyDbContext context)
    {
        _context = context;
    }

    // GET: api/Materia
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Materia>>> GetMateria()
    {
        return await _context.Materia.ToListAsync();
    }

    // GET: api/Materia/5
    [HttpGet("buscar")]
    public async Task<ActionResult<Materia>> GetMateria(int idmateria)
    {
        var materia = await _context.Materia.FindAsync(idmateria);

        if (materia == null)
        {
            return NotFound();
        }

        return materia;
    }

    // PUT: api/Materia/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{idalumno}")]
    public async Task<IActionResult> PutMateria(int? idalumno, Materia materia)
    {
        if (idalumno != materia.idMateria)
        {
            return BadRequest();
        }

        _context.Entry(materia).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MateriaExists(idalumno))
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

    // POST: api/Materia
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Materia>> PostMateria(Materia materia)
    {
        _context.Materia.Add(materia);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMateria", new { idalumno = materia.idMateria }, materia);
    }

    // DELETE: api/Materia/5
    [HttpDelete("{idalumno}")]
    public async Task<IActionResult> DeleteMateria(int? idalumno)
    {
        var materia = await _context.Materia.FindAsync(idalumno);
        if (materia == null)
        {
            return NotFound();
        }

        _context.Materia.Remove(materia);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MateriaExists(int? idalumno)
    {
        return _context.Materia.Any(e => e.idMateria == idalumno);
    }
}
