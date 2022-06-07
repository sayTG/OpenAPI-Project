using CompliantAPI.Abstractions.IServices;
using CompliantAPI.DTOs;
using CompliantAPI.Utilities.Clients;
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
        public async Task<ApiBaseResponse> AllJokeCategories()
        {
            List<string> clientResponse = await _chuckNorris.GetAllJokeCategories();
            return new ApiOkResponse<List<string>>(clientResponse);
        }
        public async Task<ApiBaseResponse> AllStarWarsPeople(int pages)
        {
            SwapiDTO clientResponse = await _swapi.AllStarWarsPeople(pages == 0 ? 1 : pages);
            return new ApiOkResponse<SwapiDTO>(clientResponse);
        }
    }
}
