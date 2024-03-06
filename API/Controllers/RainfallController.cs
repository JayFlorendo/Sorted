using Microsoft.AspNetCore.Mvc;
using Sorted.Interface;
using System.Collections.Generic;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallService _rainfallService;

        public RainfallController(IRainfallService rainfallService)
        {
            _rainfallService = rainfallService;
        }

        /// <summary>
        /// Generate a new API Key for an Organisation
        /// </summary>
        /// <param name="stationID"></param>
        /// <returns></returns>
        [HttpGet("get-rainfall/{stationID}")]
        public async Task<IActionResult> GetRainfallReadings (int stationID)
        {
             return Ok(await _rainfallService.GetRainfallReading(stationID));
        }

    }
}
