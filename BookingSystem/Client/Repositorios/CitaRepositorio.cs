using BookingSystem.Server.Models;
using System.Net.Http.Json;

namespace BookingSystem.Client.Repositorios
{
    public class CitaRepositorio : ICitaRepositorio
    {
        private readonly HttpClient _http;
        public CitaRepositorio(HttpClient httpClient) 
        { 
            _http = httpClient;
        }
        public async Task CreateCita(Cita cita)
        {
            var responde = await _http.PostAsJsonAsync("api/Cita/Guardar", cita);
        }

        public Task<List<Cita>> GetCita()
        {
            throw new NotImplementedException();
        }
    }
}
