
namespace Comunidad_Conecta_Formularios_Web.Models
{
    public class Usuario
    {
        public int id_usuario { get; set; }

        public string nombres { get; set; } = string.Empty;

        public string apellidos { get; set; } = string.Empty;

        public string correo { get; set; } = string.Empty;

        public string contrasena { get; set; } = string.Empty;

        public string? telefono { get; set; }

        public string? departamento { get; set; }

        public string? direccion { get; set; }

        public string? biografia { get; set; }

        public string? foto { get; set; }

        public string? rol { get; set; }

        public DateTime? fecha_registro { get; set; }
    }
}
