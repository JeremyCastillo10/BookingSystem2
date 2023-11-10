using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Server.Models
{
    public class ProfesionalDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int  ProfesionalId { get; set; }
        public int ServicioId { get; set; }

        public bool Visible { get; set; } = true;
    }
}
