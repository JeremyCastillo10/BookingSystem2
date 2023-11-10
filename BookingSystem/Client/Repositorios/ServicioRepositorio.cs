using BookingSystem.Server.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.WebSockets;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace BookingSystem.Client.Repositorios
{
    public class ServicioRepositorio : IServicioRepositorio
    {
        private readonly HttpClient _http;
        public ServicioRepositorio(HttpClient http)
        {

            _http = http;

        }

        public List<Servicio> Servicio { get; set ; }

        public async Task CreateServicio(Servicio servicio)
        {
            var response = await _http.PostAsJsonAsync("api/Servicio/Guardar",servicio);      
            

        }

        public async Task<bool> DeleteServicio(int id)
        {

                var response = await _http.DeleteAsync($"api/Servicio/{id}"); // Ajusta la URL según tu API.
                return response.IsSuccessStatusCode;

        }





        public async Task<List<Servicio>> GetServicio()
        {
            return await _http.GetFromJsonAsync<List<Servicio>>("api/Servicio");

        }
       

        public async Task<Servicio> GetServicioPorIdAsync(int id)
        {
            var response = await _http.GetAsync($"api/Servicio/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var servicio = JsonConvert.DeserializeObject<Servicio>(content);
                return servicio;
            }
            return null;
        }

        public async Task UpdateServicio(Servicio servicio)
        {
            var response = await _http.PutAsJsonAsync($"api/Servicio/{servicio.ServicioId}", servicio);
        }
    }
}
