using BevBuddyWebApi.Interfaces;
using BevBuddyWebApi.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Repositories
{
    public class BetRepository
    {
        private readonly IBaseRepository _baseRepository;

        public BetRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IEnumerable<Bet>> GetAllBets()
        {
            const string sql = "SELECT * FROM Bets";

            using var connection = _baseRepository.Connect();
            var bets = await connection.QueryAsync<Bet>(sql);

            return bets;
        }

        public async Task<Bet> GetBetByBetID(int betID)
        {
            const string sql = $"""
                SELECT BetID, Wager, Bettor, Description, WagerDate
                FROM Bets
                WHERE UserID = @UserID
                """;

            using var connection = _baseRepository.Connect();
            var bet = await connection.QuerySingleOrDefaultAsync<Bet>(sql, new { betID });

            return bet;
        }

        public async Task<ActionResult<Bet>> UpdateBetByBetID(Bet bet)
        {
            const string sql = $"""
                UPDATE Bets
                SET Wager = @WagerID, Bettor = @Bettor, Description = @Description, WagerDate = @WagerDate
                WHERE BetID = @BetID
                """;

            using var connection = _baseRepository.Connect();
            await connection.QueryAsync<Bet>(sql, bet);

            return bet;
        }

        public async Task<IResult> DeleteBetByBetID(BetDto request)
        {
            const string sql = $"""
                DELETE FROM Bets 
                WHERE BetID = @BetID
                """;

            using var connection = _baseRepository.Connect();
            await connection.ExecuteAsync(sql, new { request.BetID });

            return Results.Ok();
        }
    }
}
