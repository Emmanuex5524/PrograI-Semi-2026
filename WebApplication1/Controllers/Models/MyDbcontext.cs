using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Controllers.Models
{
    public class MyDbcontext : DbContext
    {

        public MyDbcontext() { } 
        public MyDbcontext(DbContextOptions<MyDbcontext> options) :base(options) { }
        public DbSet<Alumno> Alumnos {  get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Alumno>().HasKey(a => a.idAlumno); 
        }
    }
}
