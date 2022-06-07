﻿using CompliantAPI.Abstractions.IServices;
using CompliantAPI.DTOs;
using CompliantAPI.Utilities.Extensions;
using CompliantAPI.Utilities.Reponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompliantAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChuckController : ApiControllerBase
    {
        private readonly IDataService _dataService;
        public ChuckController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> Categories()
        {
            ApiBaseResponse result = await _dataService.AllJokeCategories(); 
            return Ok(result.GetResult< List<ChuckNorrisDTO>>());
        }
    }
}
