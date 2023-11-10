using BookingSystem.Server.Data;
using BookingSystem.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesionalController : ControllerBase
    {
        private readonly Contexto _contexto;
        public ProfesionalController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Profesional>>> GetProfesional()
        {
            var profesionales = await _contexto.Profesional.ToListAsync();
            return Ok(profesionales);
        }
        [HttpGet("{id}")]
        public ActionResult<Profesional> GetProfesionalPorId(int id)
        {
            var profesional = _contexto.Profesional.FirstOrDefault(p => p.ProfesionalId == id);
            return Ok(profesional);
        }
        [HttpPost]
        [Route("Guardar")]
        public async Task<ActionResult> PostProfesional(Profesional profesional)
        {
            _contexto.Add(profesional);
            await _contexto.SaveChangesAsync();
            return Ok(profesional);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProfesional(int id)
        {
            var profesional = await _contexto.Profesional.FindAsync(id);
            if (profesional == null)
            {
                return NotFound();
            }
            profesional.Visible = false;
            await _contexto.SaveChangesAsync();
            return Ok(profesional);
        

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutServicio(int id, Profesional profesional)
        {
            var Existe = await ProfesionalExiste(id);
            if (!Existe)
            {
                return NotFound();
            }
            _contexto.Update(profesional);
            await _contexto.SaveChangesAsync();
            return Ok(true);
        }

        private async Task<bool> ProfesionalExiste(int id)
        {
            return await _contexto.Profesional.AnyAsync(s => s.ProfesionalId == id);
        }
    }
}
