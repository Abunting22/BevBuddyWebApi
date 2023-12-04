using BevBuddyWebApi.Interfaces;
using BevBuddyWebApi.Models;
using BevBuddyWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BetController : ControllerBase
    {
        private readonly IBetServices _betServices;

        public BetController(IBetServices betServices)
        {
            _betServices = betServices;
        }

        [HttpGet("GetAllBets")]
        public async Task<IEnumerable<Bet>> GetAll()
        {
            return await _betServices.GetAllBets();
        }

        [HttpGet("GetBetByBetID")]
        public async Task<IActionResult> GetBetByBetID(int betID)
        {
            return Ok(await _betServices.GetBetInfo(betID));
        }

        [HttpPost("UpdateBetByBetID")]
        public async Task<ActionResult<Bet>> UpdateBetByBetID([FromBody] BetDto request)
        {
            return await _betServices.UpdateBet(request);
        }

        [HttpDelete("DeleteBetByBetID")]
        public async Task<IResult> DeleteBetByBetID([FromBody] BetDto request)
        {
            return await _betServices.DeleteBet(request);
        }
    }
}
