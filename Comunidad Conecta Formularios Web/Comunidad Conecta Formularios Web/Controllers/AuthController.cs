using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Comunidad_Conecta_Formularios_Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Comunidad_Conecta_Formularios_Web.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly ComunidadConectaContext _context;

        public AuthController(ComunidadConectaContext context)
        {
            _context = context;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> IniciarSesion(
            [FromBody] LoginRequest datos)
        {
            if (string.IsNullOrWhiteSpace(datos.correo) ||
                string.IsNullOrWhiteSpace(datos.contrasena))
            {
                return BadRequest(new
                {
                    mensaje = "Ingresa el correo y la contraseña."
                });
            }

            var correo = datos.correo.Trim();

            var usuario = await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.correo == correo);

            if (usuario == null ||
                !BCrypt.Net.BCrypt.Verify(
                    datos.contrasena,
                    usuario.contrasena))
            {
                return Unauthorized(new
                {
                    mensaje = "Correo o contraseña incorrectos."
                });
            }
            

            var claims = new List<Claim>
{
    new Claim(
        ClaimTypes.NameIdentifier,
        usuario.id_usuario.ToString()),

    new Claim(
        ClaimTypes.Name,
        $"{usuario.nombres} {usuario.apellidos}"),

    new Claim(
        ClaimTypes.Email,
        usuario.correo),

    new Claim(
        ClaimTypes.Role,
        usuario.rol ?? "Ciudadano")
};

            var identidad = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identidad);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);

            return Ok(new
            {
                mensaje = "Inicio de sesión correcto.",
                usuario = new
                {
                    usuario.id_usuario,
                    usuario.nombres,
                    usuario.apellidos,
                    usuario.correo,
                    usuario.rol
                }
            });

        }
        // POST: api/auth/logout
        [HttpPost("logout")]
        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok(new
            {
                mensaje = "Sesión cerrada correctamente."
            });
        }

        public class LoginRequest
        {
            public string correo { get; set; } = string.Empty;
            public string contrasena { get; set; } = string.Empty;
        }
    }
}
