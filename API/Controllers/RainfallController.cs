using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Sorted.Interface;
using Sorted.Model;
using Sorted.Schema;
using System.Collections.Generic;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorResponse), 500)]
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
        /// <response code="200">A list of rainfall readings successfully retrieved</response>
        /// <response code="400">Invalid request</response>
        /// <response code="404">No readings found for the specified stationId</response>
        [HttpGet("get-rainfall/{stationID}")]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        [ProducesResponseType(typeof(RainfallReadingResponse), 200)]
        public async Task<IActionResult> GetRainfallReadings (int stationID)
        {
             return Ok(await _rainfallService.GetRainfallReading(stationID));
        }

    }
}
