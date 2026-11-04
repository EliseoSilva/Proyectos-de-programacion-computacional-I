using Microsoft.EntityFrameworkCore;
namespace WebApp.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Alumnos> Alumnos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Alumnos>().HasKey(a => a.idAlumno);
        }
    }
}
