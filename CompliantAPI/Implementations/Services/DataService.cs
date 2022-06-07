using CompliantAPI.Abstractions.IClients;
using CompliantAPI.Abstractions.IServices;
using CompliantAPI.DTOs;
using CompliantAPI.Utilities.Reponses;

namespace CompliantAPI.Implementations.Services
{
    public class DataService : IDataService
    {
        private readonly IChuckNorris _chuckNorris;
        private readonly ISwapi _swapi;
        public DataService(IChuckNorris chuckNorris, ISwapi swapi)
        {
            this._chuckNorris = chuckNorris;
            this._swapi = swapi;
        }
        public async Task<ApiBaseResponse> AllJokeCategories()
        {
            List<ChuckNorrisDTO> clientResponse = await _chuckNorris.GetAllJokeCategories();
            return new ApiOkResponse<List<ChuckNorrisDTO>>(clientResponse);
        }
        public async Task<ApiBaseResponse> AllStarWarsPeople(int pages)
        {
            SwapiDTO clientResponse = await _swapi.AllStarWarsPeople(pages == 0 ? 1 : pages);
            return new ApiOkResponse<SwapiDTO>(clientResponse);
        }
    }
}
