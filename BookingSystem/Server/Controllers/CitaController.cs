using BookingSystem.Server.Data;
using BookingSystem.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BookingSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly Contexto _contexto;

        public CitaController(Contexto contexto)
        {
           _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cita>>> GetCita()
        {
            var citas = await _contexto.Cita.ToListAsync();
            return Ok(citas);
        }
        [HttpGet]
        [Route("ExisteCita/{hora}/{fecha}/{profesionalId}/{servicioId}")]
        public async Task<ActionResult<bool>> ExisteCita(string hora, DateTime fecha, int profesionalId, int servicioId)
        {
            var citaExistente = await _contexto.Cita
                .Where(c => c.Hora == hora && c.Fecha == fecha && c.ProfesionalId == profesionalId && c.ServicioId == servicioId)
                .FirstOrDefaultAsync();

            if (citaExistente != null)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
        [HttpPost]
        [Route("Guarda")]
        public async Task<ActionResult> PostCita2(Cita cita)
        {
            // Verificar si ya existe una cita con la misma información
            bool citaExistente = await _contexto.Cita.AnyAsync(c => c.Hora == cita.Hora && c.Fecha == cita.Fecha && c.ProfesionalId == cita.ProfesionalId && c.ServicioId ==  cita.ServicioId);

            if (citaExistente)
            {
                // Puedes devolver un error o un mensaje indicando que la cita ya existe
                return BadRequest("Ya existe una cita con la misma información.");
            }

            // Si no existe, agregar la nueva cita a la base de datos
            _contexto.Add(cita);
            await _contexto.SaveChangesAsync();

            return Ok(cita);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<ActionResult> PostCita(Cita cita)
        {

            _contexto.Add(cita);
            await _contexto.SaveChangesAsync();
            return Ok(cita);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Cita>>> GetCitasPorUser(string id)
        {
            var response = await _contexto.Cita.Where(c => c.UserId == id).ToListAsync();
            return Ok(response);
        }
     
    }
}
