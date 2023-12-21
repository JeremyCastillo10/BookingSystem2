using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Shared.DTOs
{
    public class Historial_M
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Servicio { get; set; }
        public string Hora { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
    }
}
