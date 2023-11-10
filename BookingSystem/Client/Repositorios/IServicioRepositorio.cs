using BookingSystem.Server.Models;
using Microsoft.AspNetCore.Components;

namespace BookingSystem.Client.Repositorios
{
    public interface IServicioRepositorio
    {
        List<Servicio> Servicio{ get; set; }
        Task<List<Servicio>> GetServicio();
        Task<Servicio> GetServicioPorIdAsync(int id);
        Task<bool> DeleteServicio(int id);
        Task UpdateServicio(Servicio servicio);
        Task CreateServicio(Servicio servicio);
    }
}
