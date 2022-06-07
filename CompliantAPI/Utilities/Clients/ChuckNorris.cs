using CompliantAPI.DTOs;

namespace CompliantAPI.Utilities.Clients
{
    public class ChuckNorris
    {
        private readonly HttpClient _httpClient;

        public ChuckNorris(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<List<string>> GetAllJokeCategories() => await _httpClient.GetFromJsonAsync<List<string>>("jokes/categories") ?? throw new Exception("Failed to get response");
    }
}
