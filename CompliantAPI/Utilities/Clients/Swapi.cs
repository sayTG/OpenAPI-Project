using CompliantAPI.DTOs;

namespace CompliantAPI.Utilities.Clients
{
    public class Swapi
    {
        private readonly HttpClient _httpClient;

        public Swapi(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<SwapiDTO> AllStarWarsPeople(int page) => await _httpClient.GetFromJsonAsync<SwapiDTO>($"people/?page = {page}") ?? throw new Exception("Failed to get response");
    }
}
