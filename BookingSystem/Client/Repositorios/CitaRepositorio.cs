using BookingSystem.Server.Models;
using System.Net.Http;
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
        public async Task<bool> CreateCita(Cita cita)
        {
            var responde = await _http.PostAsJsonAsync("api/Cita/Guarda", cita);
            return responde.IsSuccessStatusCode;
        }

        public Task<List<Cita>> GetCita()
        {
            throw new NotImplementedException();
        }
        public async Task<bool> ExisteCita(string hora, DateTime fecha, int profesionalId, int servicioId)
        {
            try
            {
                var response = await _http.GetAsync($"api/Cita/ExisteCita/{hora}/{fecha}/{profesionalId}/{servicioId}");

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    if (bool.TryParse(responseContent, out bool existeCita))
                    {
                        return existeCita;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return false;
            }
        }


    }
}
