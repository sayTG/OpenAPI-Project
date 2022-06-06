using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompliantAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SwapiController : ApiControllerBase
    {
        [HttpGet("people")]
        public IActionResult People()
        {
            return Ok(string.Empty);
        }
    }
}
