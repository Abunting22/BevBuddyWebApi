using BevBuddyWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Interfaces
{
    public interface IBetServices
    {
        public Task<IEnumerable<Bet>> GetAllBets();

        public Task<Bet> GetBetInfo(int betID);

        public Task<ActionResult<Bet>> UpdateBet(BetDto request);

        public Task<IResult> DeleteBet(BetDto request);
    }
}
