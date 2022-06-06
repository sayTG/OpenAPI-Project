using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompliantAPI.Controllers
{
    [ApiController]
    public class SearchController : ApiControllerBase
    {
        [HttpGet("search")]
        public IActionResult Search()
        {
            return Ok(string.Empty);
        }
    }
}
