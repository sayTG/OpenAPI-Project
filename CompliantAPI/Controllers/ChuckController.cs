﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompliantAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChuckController : ApiControllerBase
    {

        [HttpGet("categories")]
        public IActionResult Categories()
        {
            return Ok(string.Empty);
        }
    }
}
