using CompliantAPI.DTOs;

namespace CompliantAPI.Abstractions.IClients
{
    public interface IChuckNorris
    {
        Task<List<ChuckNorrisDTO>> GetAllJokeCategories();
    }
}
