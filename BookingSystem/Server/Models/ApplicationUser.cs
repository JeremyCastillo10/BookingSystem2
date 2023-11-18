using Microsoft.AspNetCore.Identity;

namespace BookingSystem.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string  NombreCompleto { get; set; }
        public string Direccion  { get; set; }
        public string Telefono { get; set; }
    }
}