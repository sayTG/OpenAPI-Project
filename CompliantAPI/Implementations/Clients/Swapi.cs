using CompliantAPI.Abstractions.IClients;
using CompliantAPI.DTOs;

namespace CompliantAPI.Implementations.Clients
{
    public class Swapi : ISwapi
    {
        private readonly HttpClient _httpClient;

        public Swapi(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<SwapiDTO> AllStarWarsPeople(int page) => await _httpClient.GetFromJsonAsync<SwapiDTO>($"people/{page}") ?? throw new Exception("Failed to get response");
    }
}
