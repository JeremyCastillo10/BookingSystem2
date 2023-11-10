using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystem.Server.Models
{
    public class Profesional
    {
        [Key]
        public int ProfesionalId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string NombreCompleto { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Telefono { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public DateTime? FechaIngreso { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Campo Obligatorio")]
        public string Especialidad { get; set; }
        public bool Visible { get; set; } = true;

    }

}
