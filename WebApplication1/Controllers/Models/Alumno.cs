using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Controllers.Models
{
    public class Alumno
    {
        [Key]
        public int idAlumno { get; set; }
        public int codigo { get; set; }
        public int nombre { get; set; }
        public int direccion { get; set; }
        public int telefono { get; set; }
        public int email { get; set; }    
    }
}
