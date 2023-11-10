using BookingSystem.Server.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BookingSystem.Client.Repositorios
{
    public class ProfesionalRepositorio : IProfesionalRepositorio
    {
        private readonly HttpClient _http;
        public ProfesionalRepositorio(HttpClient httpClient)
        {
            _http = httpClient;
            
        }

        public async Task CreateProfesional(Profesional profesional)
        {
            var response = _http.PostAsJsonAsync("api/Profesional/Guardar", profesional);
        }

        public async Task<bool> DeleteProfesional(int id)
        {
            var response = await _http.DeleteAsync($"api/Profesional/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Profesional>> GetProfesional()
        {
            return await _http.GetFromJsonAsync<List<Profesional>>("api/Profesional");
        }

        public async Task<Profesional> GetProfesionalPorIdAsync(int id)
        {
           var response = await _http.GetAsync($"api/Profesional/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var profesional = JsonConvert.DeserializeObject<Profesional>(content);
                return profesional;
            }
            return null;
        }

        public async Task UpdateProfesional(Profesional profesional)
        {
            var response = await _http.PutAsJsonAsync($"api/Profesional/{profesional.ProfesionalId}", profesional);
        }
    }
}
