using CompliantAPI.Abstractions.IServices;
using CompliantAPI.DTOs;
using CompliantAPI.Utilities.Clients;
using CompliantAPI.Utilities.Extensions;
using CompliantAPI.Utilities.Reponses;

namespace CompliantAPI.Implementations.Services
{
    public class DataService : IDataService
    {
        private readonly ChuckNorris _chuckNorris;
        private readonly Swapi _swapi;
        public DataService(ChuckNorris chuckNorris, Swapi swapi)
        {
            this._chuckNorris = chuckNorris;
            this._swapi = swapi;
        }
        public async Task<ApiBaseResponse> AllJokeCategories() => await _chuckNorris.GetAllJokeCategories();
        public async Task<ApiBaseResponse> AllStarWarsPeople(int pages) => await _swapi.AllStarWarsPeople(pages == 0 ? 1 : pages);
        public async Task<ApiBaseResponse> SearchChuckNorris_Swapi(string query, int page)
        {
            ChuckNorris_SwapDTO chuckNorris_Swap = new ChuckNorris_SwapDTO();
            ApiBaseResponse chuckResponse = await _chuckNorris.SearchChuckNorrisJokes(query);
            ApiBaseResponse swapResponse = await _swapi.SearchStarWarsPeople(query, page);

            if (chuckResponse.Success)  chuckNorris_Swap.ChuckNorris = chuckResponse.GetResult<dynamic>();
            if (swapResponse.Success) chuckNorris_Swap.Swapi = swapResponse.GetResult<SwapiDTO>();

            if (!chuckResponse.Success && !swapResponse.Success) return new ApiNoContentResponse("No data");

            return new ApiOkResponse<ChuckNorris_SwapDTO>(chuckNorris_Swap);
        }
    }
}
