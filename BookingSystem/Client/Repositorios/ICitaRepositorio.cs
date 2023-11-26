using BookingSystem.Server.Models;

namespace BookingSystem.Client.Repositorios
{
    public interface ICitaRepositorio
    {
        Task<List<Cita>> GetCita();
        Task CreateCita(Cita cita);
    }
}
