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
    public class SwapiController : ApiControllerBase
    {
        private readonly IDataService _dataService;
        public SwapiController(IDataService dataService)
        {
            _dataService = dataService;
        }
        [HttpGet("people")]
        public async Task<IActionResult> People(int pages = 1)
        {
            ApiBaseResponse result = await _dataService.AllStarWarsPeople(pages);
            return Ok(result.GetResult<SwapiDTO>());
        }
    }
}
