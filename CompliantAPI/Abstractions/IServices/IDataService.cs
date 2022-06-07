using CompliantAPI.Utilities.Reponses;

namespace CompliantAPI.Abstractions.IServices
{
    public interface IDataService
    {
        Task<ApiBaseResponse> AllJokeCategories();
        Task<ApiBaseResponse> AllStarWarsPeople(int pages);
    }
}
