using Comunidad_Conecta_Formularios_Web.Data;
using Comunidad_Conecta_Formularios_Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Comunidad_Conecta_Formularios_Web.Controllers
{
    [Authorize]
    [ApiController] 
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly ComunidadConectaContext _context;

        public UsuariosController(ComunidadConectaContext context)
        {
            _context = context;
        }

        // GET: api/usuarios
        [HttpGet]
        public async Task<IActionResult> ObtenerUsuarios()
        {
            var usuarios = await _context.Usuarios
                .AsNoTracking()
                .Select(u => new
                {
                    u.id_usuario,
                    u.nombres,
                    u.apellidos,
                    u.correo,
                    u.telefono,
                    u.departamento,
                    u.direccion,
                    u.biografia,
                    u.foto,
                    u.rol,
                    u.fecha_registro
                })
                .ToListAsync();

            return Ok(usuarios);
        }

        // GET: api/usuarios/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            var usuario = await _context.Usuarios
                .AsNoTracking()
                .Where(u => u.id_usuario == id)
                .Select(u => new
                {
                    u.id_usuario,
                    u.nombres,
                    u.apellidos,
                    u.correo,
                    u.telefono,
                    u.departamento,
                    u.direccion,
                    u.biografia,
                    u.foto,
                    u.rol,
                    u.fecha_registro
                })
                .FirstOrDefaultAsync();

            if (usuario == null)
                return NotFound(new { mensaje = "Usuario no encontrado." });

            return Ok(usuario);
        }

        // PUT: api/usuarios/1
        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditarUsuario(
            int id,
            [FromBody] EditarUsuarioRequest datos)
        {
            if (string.IsNullOrWhiteSpace(datos.nombres) ||
                string.IsNullOrWhiteSpace(datos.apellidos) ||
                string.IsNullOrWhiteSpace(datos.correo))
            {
                return BadRequest(new
                {
                    mensaje = "Nombres, apellidos y correo son obligatorios."
                });
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.id_usuario == id);

            if (usuario == null)
                return NotFound(new { mensaje = "Usuario no encontrado." });

            var correo = datos.correo.Trim();

            bool correoExiste = await _context.Usuarios.AnyAsync(u =>
                u.correo == correo && u.id_usuario != id);

            if (correoExiste)
                return Conflict(new { mensaje = "Ese correo ya está registrado." });

            usuario.nombres = datos.nombres.Trim();
            usuario.apellidos = datos.apellidos.Trim();
            usuario.correo = correo;
            usuario.telefono = datos.telefono;
            usuario.departamento = datos.departamento;
            usuario.direccion = datos.direccion;
            usuario.biografia = datos.biografia;
            usuario.foto = datos.foto;
            usuario.rol = datos.rol;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Usuario actualizado correctamente.",
                usuario.id_usuario,
                usuario.nombres,
                usuario.apellidos,
                usuario.correo,
                usuario.rol
            });
        }

        // DELETE: api/usuarios/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.id_usuario == id);

            if (usuario == null)
            {
                return NotFound(new
                {
                    mensaje = "Usuario no encontrado."
                });
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = "Usuario eliminado correctamente."
            });
        }


        // POST: api/usuarios
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CrearUsuario(
            [FromBody] CrearUsuarioRequest datos)
        {
            if (string.IsNullOrWhiteSpace(datos.nombres) ||
                string.IsNullOrWhiteSpace(datos.apellidos) ||
                string.IsNullOrWhiteSpace(datos.correo) ||
                string.IsNullOrWhiteSpace(datos.contrasena))
            {
                return BadRequest(new
                {
                    mensaje = "Nombres, apellidos, correo y contraseña son obligatorios."
                });
            }

            var correo = datos.correo.Trim();

            bool correoExiste = await _context.Usuarios
                .AnyAsync(u => u.correo == correo);

            if (correoExiste)
            {
                return Conflict(new
                {
                    mensaje = "Ese correo ya está registrado."
                });
            }

            var usuario = new Usuario
            {
                nombres = datos.nombres.Trim(),
                apellidos = datos.apellidos.Trim(),
                correo = correo,
                contrasena = BCrypt.Net.BCrypt.HashPassword(datos.contrasena),
                telefono = datos.telefono,
                departamento = datos.departamento,
                direccion = datos.direccion,
                biografia = datos.biografia,
                foto = datos.foto,
                rol = "Ciudadano",
                fecha_registro = DateTime.Now
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(ObtenerUsuario),
                new { id = usuario.id_usuario },
                new
                {
                    mensaje = "Usuario registrado correctamente.",
                    usuario.id_usuario,
                    usuario.nombres,
                    usuario.apellidos,
                    usuario.correo,
                    usuario.rol
                });
        }

        // DTO para editar perfil sin modificar la contraseña.
        public class EditarUsuarioRequest
        {
            public string nombres { get; set; } = string.Empty;
            public string apellidos { get; set; } = string.Empty;
            public string correo { get; set; } = string.Empty;
            public string? telefono { get; set; }
            public string? departamento { get; set; }
            public string? direccion { get; set; }
            public string? biografia { get; set; }
            public string? foto { get; set; }
            public string? rol { get; set; }
        }

        public class CrearUsuarioRequest
        {
            public string nombres { get; set; } = string.Empty;
            public string apellidos { get; set; } = string.Empty;
            public string correo { get; set; } = string.Empty;
            public string contrasena { get; set; } = string.Empty;
            public string? telefono { get; set; }
            public string? departamento { get; set; }
            public string? direccion { get; set; }
            public string? biografia { get; set; }
            public string? foto { get; set; }
        }

    }
}
