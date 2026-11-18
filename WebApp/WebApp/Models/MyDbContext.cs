using Microsoft.EntityFrameworkCore;
namespace WebApp.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<WebApp.Models.Materia> Materia { get; set; } = default!;
        public MyDbContext() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<alumnos> Alumnos { get; set; }
        public DbSet<Materia> Materias { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<alumnos>().HasKey(a => a.idAlumno);
            modelBuilder.Entity<Materia>().HasKey(m => m.idMateria);
        }

    }
}
