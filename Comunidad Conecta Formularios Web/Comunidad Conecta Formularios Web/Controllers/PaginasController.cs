
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Comunidad_Conecta_Formularios_Web.Controllers
{
    [Route("paginas")]
    public class PaginasController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public PaginasController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [AllowAnonymous]
        [HttpGet("registro.html")]
        public IActionResult Registro()
        {
            return PhysicalFile(
                Path.Combine(_environment.WebRootPath, "paginas", "registro.html"),
                "text/html");
        }

        [Authorize]
        [HttpGet("inicio.html")]
        public IActionResult Inicio()
        {
            return PaginaPrivada("inicio.html");
        }

        [Authorize]
        [HttpGet("usuarios.html")]
        public IActionResult Usuarios()
        {
            return PaginaPrivada("usuarios.html");
        }

        [Authorize]
        [HttpGet("donaciones.html")]
        public IActionResult Donaciones()
        {
            return PaginaPrivada("donaciones.html");
        }

        [Authorize]
        [HttpGet("solicitudes.html")]
        public IActionResult Solicitudes()
        {
            return PaginaPrivada("solicitudes.html");
        }

        [Authorize]
        [HttpGet("mascotas.html")]
        public IActionResult Mascotas()
        {
            return PaginaPrivada("mascotas.html");
        }

        private IActionResult PaginaPrivada(string archivo)
        {
            var ruta = Path.Combine(
                _environment.WebRootPath,
                "paginas",
                archivo);

            if (!System.IO.File.Exists(ruta))
                return NotFound();

            return PhysicalFile(ruta, "text/html");
        }
    }
}
