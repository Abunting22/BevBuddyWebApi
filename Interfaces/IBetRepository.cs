using BevBuddyWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Interfaces
{
    public interface IBetRepository
    {
        public Task<IEnumerable<Bet>> GetAllBets();

        public Task<Bet> GetBetByBetID(int betID);

        public Task<ActionResult<Bet>> UpdateBetByBetID(Bet bet);

        public Task<IResult> DeleteBetByBetID(BetDto request);

    }
}
