using BevBuddyWebApi.Interfaces;
using BevBuddyWebApi.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace BevBuddyWebApi.Repositories
{
    public class BetRepository : IBetRepository
    {
        private readonly IBaseRepository _baseRepository;

        public BetRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<ActionResult<Bet>> CreateNewBet(Bet bet)
        {
            const string sql = $"""
                INSERT INTO Bets (UserID, Bettor, Wager, Description, WagerDate)
                VALUES (@UserID, @Bettor, @Wager, @Description, @WagerDate)
                """;
            using var connection = _baseRepository.Connect();
            await connection.QueryAsync(sql, bet);

            return bet;
        }

        public async Task<IEnumerable<Bet>> GetAllBets()
        {
            const string sql = "SELECT * FROM Bets";

            using var connection = _baseRepository.Connect();
            var bets = await connection.QueryAsync<Bet>(sql);

            return bets;
        }

        public async Task<IEnumerable<Bet>> GetBetsByUserID(int userID)
        {
            const string sql = $"""
                SELECT Bets.BetID, Bets.Bettor, Bets.Wager, Bets.Description, Bets.WagerDate
                FROM Bets
                RIGHT JOIN Users
                ON Bets.UserID = Users.UserID
                """;

            using var connection = _baseRepository.Connect();
            var bets = await connection.QueryAsync<Bet>(sql, new { userID });

            return bets;
        }

        public async Task<ActionResult<Bet>> UpdateBetByBetID(Bet bet)
        {
            const string sql = $"""
                UPDATE Bets
                SET Bettor = @Bettor, Wager = @Wager, Description = @Description, WagerDate = @WagerDate
                WHERE BetID = @BetID AND UserID = @UserID
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
