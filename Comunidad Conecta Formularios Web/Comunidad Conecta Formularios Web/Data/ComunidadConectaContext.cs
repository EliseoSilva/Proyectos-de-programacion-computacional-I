
using Comunidad_Conecta_Formularios_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Comunidad_Conecta_Formularios_Web.Data
{
    public class ComunidadConectaContext : DbContext
    {
        public ComunidadConectaContext(
            DbContextOptions<ComunidadConectaContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIOS");
                entity.HasKey(e => e.id_usuario);
            });

            base.OnModelCreating(modelBuilder);
        }
    }

}
