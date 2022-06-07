using CompliantAPI.DTOs;
using CompliantAPI.Utilities.Reponses;

namespace CompliantAPI.Utilities.Clients
{
    public class Swapi
    {
        private readonly HttpClient _httpClient;

        public Swapi(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<ApiBaseResponse> AllStarWarsPeople(int page)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"people/?page={page}");
            if (response.IsSuccessStatusCode)
            {
                SwapiDTO? result = await response.Content.ReadFromJsonAsync<SwapiDTO>();
                return new ApiOkResponse<SwapiDTO?>(result);
            }
            else return new ApiNoContentResponse("No data");
        }
    }
}
