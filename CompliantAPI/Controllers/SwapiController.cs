using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompliantAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SwapiController : ControllerBase
    {
        [HttpGet("people")]
        public IActionResult People()
        {
            return Ok(string.Empty);
        }
    }
}
