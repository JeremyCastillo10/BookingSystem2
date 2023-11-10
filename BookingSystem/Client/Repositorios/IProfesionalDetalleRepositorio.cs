using BookingSystem.Server.Models;

namespace BookingSystem.Client.Repositorios
{
    public interface IProfesionalDetalleRepositorio
    {
        Task<List<ProfesionalDetalle>> GetProfesionalDetalles();
        Task CreateProfesionalDetalle(ProfesionalDetalle profesionalDetalle);
        Task<bool> DeleteProfesionalDetalle(int id);
        Task<ProfesionalDetalle> GetProfesionalDetallePorIdAsync(int id);
    }
}
