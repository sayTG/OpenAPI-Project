using CompliantAPI.DTOs;

namespace CompliantAPI.Abstractions.IClients
{
    public interface ISwapi
    {
        Task<SwapiDTO> AllStarWarsPeople(int page);
    }
}
