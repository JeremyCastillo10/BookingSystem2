using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookingSystem.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public int UsuarioId { get; set; }
        public string  NombreCompleto { get; set; }
        public string Direccion  { get; set; }
        public string Telefono { get; set; }
    }
}