using BookingSystem.Server.Data;
using BookingSystem.Server.Models;
using BookingSystem.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly Contexto _contexto;

        public UserController(Contexto contexto)
        {
           _contexto = contexto;
        }
        [HttpGet]
        public async Task<ActionResult<List<ApplicationUser>>> GetUsers()
        {
            var response = await _contexto.UsuarioAplicacion.ToListAsync();
            return Ok(response);
        }

    }
}
