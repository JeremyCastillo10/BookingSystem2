using BookingSystem.Server.Data;
using BookingSystem.Server.Models;
using BookingSystem.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookingSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ServicioController : ControllerBase
    {
        private readonly Contexto _contexto;

        public ServicioController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Servicio>>> GetServicio()
        {
            var servicio = await _contexto.Servicio.Where(s => s.Visible == true).ToListAsync();
            return Ok(servicio);
        }
        [HttpGet("{id}")]
        public ActionResult<Servicio> GetServicioPorId(int id)
        {
            var servicio = _contexto.Servicio.FirstOrDefault(h => h.ServicioId == id && h.Visible == true);
            return Ok(servicio);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<ActionResult> PostServicio(Servicio servicio)
        {
            _contexto.Add(servicio);
            await _contexto.SaveChangesAsync();
            return Ok(servicio);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteServicio(int id)
        {
            var dbservicio = await _contexto.Servicio.FindAsync(id);
            if (dbservicio == null)
            {
                return NotFound(); 
            }

            dbservicio.Visible = false;

            await _contexto.SaveChangesAsync();

            return Ok(true); 
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutServicio(int id, Servicio servicio)
        {
            var servicioExiste = await ServicioExiste(id);
            if(!servicioExiste)
            {
                return NotFound();
            }
            _contexto.Update(servicio);
            await _contexto.SaveChangesAsync();
            return Ok(true);
        }

        private async Task<bool> ServicioExiste(int id)
        {
            return await _contexto.Servicio.AnyAsync(s => s.ServicioId == id);
        }


    }
}
