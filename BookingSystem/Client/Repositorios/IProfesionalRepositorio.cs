using BookingSystem.Server.Models;

namespace BookingSystem.Client.Repositorios
{
    public interface IProfesionalRepositorio
    {
        Task<List<Profesional>> GetProfesional();
        Task CreateProfesional(Profesional profesional);
        Task<Profesional> GetProfesionalPorIdAsync(int id);
        Task<bool> DeleteProfesional(int id);
        Task UpdateProfesional(Profesional profesional);
    }
}
