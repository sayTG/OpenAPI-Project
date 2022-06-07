using CompliantAPI.Abstractions.IClients;
using CompliantAPI.DTOs;

namespace CompliantAPI.Implementations.Clients
{
    public class ChuckNorris : IChuckNorris
    {
        private readonly HttpClient _httpClient;

        public ChuckNorris(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<List<ChuckNorrisDTO>> GetAllJokeCategories() => await _httpClient.GetFromJsonAsync<List<ChuckNorrisDTO>>("jokes/categories") ?? throw new Exception("Failed to get response");
    }
}
