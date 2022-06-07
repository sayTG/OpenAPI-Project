using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompliantAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchController : ApiControllerBase
    {
        [HttpGet]
        public IActionResult Search()
        {
            return Ok(string.Empty);
        }
    }
}
