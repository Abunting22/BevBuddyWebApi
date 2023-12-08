using BevBuddyWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Interfaces
{
    public interface IBetRepository
    {
        public Task<ActionResult<Bet>> CreateNewBet(Bet bet);

        public Task<IEnumerable<Bet>> GetAllBets();

        public Task<IEnumerable<Bet>> GetBetsByUserID(int userID);

        public Task<ActionResult<Bet>> UpdateBetByBetID(Bet bet);

        public Task<IResult> DeleteBetByBetID(BetDto request);

    }
}
