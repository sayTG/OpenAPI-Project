using CompliantAPI.Utilities.Reponses;

namespace CompliantAPI.Abstractions.IServices
{
    public interface IDataService
    {
        Task<ApiBaseResponse> AllJokeCategories();
        Task<ApiBaseResponse> AllStarWarsPeople(int pages);
        Task<ApiBaseResponse> SearchChuckNorris_Swapi(string query, int page);
    }
}
