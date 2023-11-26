using BookingSystem.Server.Models;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookingSystem.Server.Data
{
    public class Contexto : ApiAuthorizationDbContext<ApplicationUser>
    {
        public Contexto(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
        public DbSet<Profesional> Profesional { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<ApplicationUser> UsuarioAplicacion { get; set; }
        public DbSet<ProfesionalDetalle> ProfesionalDetalle { get; set; }
        public DbSet<Cita> Cita { get; set; }
    }
}