using CompliantAPI.Utilities.Reponses;

namespace CompliantAPI.Utilities.Clients
{
    public class ChuckNorris
    {
        private readonly HttpClient _httpClient;

        public ChuckNorris(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<ApiBaseResponse> GetAllJokeCategories()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("jokes/categories");
            if (response.IsSuccessStatusCode)
            {
                List<string>? result = await response.Content.ReadFromJsonAsync<List<string>>();
                return new ApiOkResponse<List<string>?>(result);
            }
            else return new ApiNoContentResponse("No data");
        }
        public async Task<ApiBaseResponse> SearchChuckNorrisJokes(string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"jokes/search?query={query}");
            if (response.IsSuccessStatusCode)
            {
                dynamic? result = await response.Content.ReadFromJsonAsync<dynamic>();
                return new ApiOkResponse<dynamic>(result);
            }
            else return new ApiNoContentResponse("No data");
        }
    }
}
