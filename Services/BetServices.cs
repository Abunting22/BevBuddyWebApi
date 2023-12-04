using BevBuddyWebApi.Interfaces;
using BevBuddyWebApi.Models;
using BevBuddyWebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Services
{
    public class BetServices
    {
        private readonly IBetRepository _betRepository;
        private readonly Bet _bet;

        public BetServices(IBetRepository betRepository, Bet bet)
        {
            _betRepository = betRepository;
            _bet = bet;
        }

        public async Task<IEnumerable<Bet>> GetAllBets()
        {
            return await _betRepository.GetAllBets();
        }

        public async Task<Bet> GetBetInfo(int betID)
        {
            var bet = await _betRepository.GetBetByBetID(betID);

            if (bet == null)
                throw new ArgumentNullException(nameof(bet));

            return bet;
        }

        public async Task<ActionResult<Bet>> UpdateBet(BetDto request)
        {
            Bet bet = new()
            {
                Wager = request.Wager,
                Bettor = request.Bettor,
                Description = request.Description,
                WagerDate = request.WagerDate,
            };

            return await _betRepository.UpdateBetByBetID(bet);
        }

        public async Task<IResult> DeleteBet(BetDto request)
        {
            await _betRepository.DeleteBetByBetID(request);

            return Results.Ok();
        }
    }
}
