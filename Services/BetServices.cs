using BevBuddyWebApi.Interfaces;
using BevBuddyWebApi.Models;
using BevBuddyWebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Services
{
    public class BetServices : IBetServices
    {
        private readonly IBetRepository _betRepository;
        private readonly IUserServices _userServices;
        private readonly Bet _bet;

        public BetServices(IBetRepository betRepository, IUserServices userServices, Bet bet)
        {
            _betRepository = betRepository;
            _userServices = userServices;
            _bet = bet;
        }

        public async Task<ActionResult<Bet>> CreateNewBet(BetDto request)
        {
            Bet bet = new()
            {
                UserID = request.UserID,
                Bettor = request.Bettor,
                Wager = request.Wager,
                Description = request.Description,
                WagerDate = request.WagerDate
            };

            return await _betRepository.CreateNewBet(bet);
        }

        public async Task<IEnumerable<Bet>> GetAllBets()
        {
            return await _betRepository.GetAllBets();
        }

        public async Task<IEnumerable<Bet>> GetBetInfo(int userID)
        {
            var bet = await _betRepository.GetBetsByUserID(userID);

            if (bet == null)
                throw new ArgumentNullException(nameof(bet));

            return bet;
        }

        public async Task<ActionResult<Bet>> UpdateBet(BetDto request)
        {
            Bet bet = new()
            {
                BetID = request.BetID,
                UserID = request.UserID,
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
