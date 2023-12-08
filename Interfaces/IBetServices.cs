using BevBuddyWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Interfaces
{
    public interface IBetServices
    {
        public Task<ActionResult<Bet>> CreateNewBet(BetDto request);

        public Task<IEnumerable<Bet>> GetAllBets();

        public Task<IEnumerable<Bet>> GetBetInfo(int userID);

        public Task<ActionResult<Bet>> UpdateBet(BetDto request);

        public Task<IResult> DeleteBet(BetDto request);
    }
}
