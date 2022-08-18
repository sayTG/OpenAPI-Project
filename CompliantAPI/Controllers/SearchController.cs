using CompliantAPI.Abstractions.IServices;
using CompliantAPI.DTOs;
using CompliantAPI.Utilities.Extensions;
using CompliantAPI.Utilities.Reponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompliantAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchController : ApiControllerBase
    {
        private readonly IDataService _dataService;
        public SearchController(IDataService dataService)
        {
            _dataService = dataService;
        }
        [HttpGet]
        public async Task<IActionResult> Search(string query, int page = 1)
        {
            ApiBaseResponse response = await _dataService.SearchChuckNorris_Swapi(query, page);
            if (!response.Success)
                return ProcessError(response);
            return Ok(response.GetResult<ChuckNorris_SwapDTO>());
        }
    }
}
