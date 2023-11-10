using BookingSystem.Server.Data;
using BookingSystem.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesionalDetalleController : ControllerBase
    {
        private readonly Contexto _contexto;
        public ProfesionalDetalleController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Profesional>>> GetProfesionalDetalle()
        {
            var obj = await _contexto.ProfesionalDetalle.ToListAsync();
            return Ok(obj);
        }
        [HttpGet("id")]
        public async Task<ActionResult> GetProfesionalDetallePorId(int id)
        {
            var obj = await _contexto.ProfesionalDetalle.FirstOrDefaultAsync(p => p.DetalleId == id);
            return Ok(obj);
        }
        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> PostProfesionalDetalle(ProfesionalDetalle profesionalDetalle)
        {
            _contexto.Add(profesionalDetalle);
            await _contexto.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("id")]
        public async Task<ActionResult> DeleteProfesionalDetalle(int id)
        {
            var obj = await _contexto.ProfesionalDetalle.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            obj.Visible = false;
            await _contexto.SaveChangesAsync();
            return Ok();
        }
    }
}
