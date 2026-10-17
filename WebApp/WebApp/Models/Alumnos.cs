
using System.ComponentModel.DataAnnotations;
namespace WebApp.Models
{
    public class Alumnos
    {
        [Key]
        public int idAlumno { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
    }
}
