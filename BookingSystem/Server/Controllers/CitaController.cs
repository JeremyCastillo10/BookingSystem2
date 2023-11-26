using BookingSystem.Server.Data;
using BookingSystem.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        [Route("Guardar")]
        public async Task<ActionResult> PostCita(Cita cita)
        {
            _contexto.Add(cita);
            await _contexto.SaveChangesAsync();
            return Ok(cita);
        }
    }
}
