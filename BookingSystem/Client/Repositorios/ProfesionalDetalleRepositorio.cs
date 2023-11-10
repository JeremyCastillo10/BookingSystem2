using BookingSystem.Server.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BookingSystem.Client.Repositorios
{
    public class ProfesionalDetalleRepositorio : IProfesionalDetalleRepositorio
    {
        private readonly HttpClient _http;
        public ProfesionalDetalleRepositorio(HttpClient httpClient)
        {
            _http = httpClient;
        }
        public async Task CreateProfesionalDetalle(ProfesionalDetalle profesionalDetalle)
        {
            var response = await _http.PostAsJsonAsync("api/ProfesionalDetalle/Guardar", profesionalDetalle);
            
        }

        public async Task<bool> DeleteProfesionalDetalle(int id)
        {
            var response = _http.DeleteAsync($"api/ProfesionalDetalle/{id}");
            return response.IsCompletedSuccessfully;
        }

        public async Task<ProfesionalDetalle> GetProfesionalDetallePorIdAsync(int id)
        {
            var response = await _http.GetAsync($"api/ProfesionalDetalle/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var profesional = JsonConvert.DeserializeObject<ProfesionalDetalle>(content);
                return profesional;
            }
            return null;
        }

        public async Task<List<ProfesionalDetalle>> GetProfesionalDetalles()
        {
            return await _http.GetFromJsonAsync<List<ProfesionalDetalle>>("api/ProfesionalDetalle");
            
        }
    }
}
