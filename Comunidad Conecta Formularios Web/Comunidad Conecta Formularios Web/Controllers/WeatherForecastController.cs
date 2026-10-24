
using Comunidad_Conecta_Formularios_Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace Comunidad_Conecta_Formularios_Web.Controllers
{
    [ApiController]
    [Route("api/diagnostico")]
    public class DiagnosticoController : ControllerBase
    {
        private readonly ComunidadConectaContext _context;

        public DiagnosticoController(ComunidadConectaContext context)
        {
            _context = context;
        }

        [HttpGet("base-datos")]
        public async Task<IActionResult> ProbarBaseDatos()
        {
            try
            {
                bool conectado =
                    await _context.Database.CanConnectAsync();

                if (!conectado)
                {
                    return StatusCode(503, new
                    {
                        conectado = false,
                        mensaje = "No fue posible conectarse a SQL Server."
                    });
                }

                return Ok(new
                {
                    conectado = true,
                    mensaje = "Conexión establecida correctamente."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    conectado = false,
                    mensaje = "Error al conectar con SQL Server.",
                    detalle = ex.Message
                });
            }
        }
    }
}
