using BookingSystem.Server.Models;

namespace BookingSystem.Client.Repositorios
{
    public interface ICitaRepositorio
    {
        Task<List<Cita>> GetCita();
        Task<bool> CreateCita(Cita cita);
        Task<bool> ExisteCita(string hora, DateTime fecha, int profesionalId, int servicioId);
    }
}
