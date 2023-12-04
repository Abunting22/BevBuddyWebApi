using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BevBuddyWebApi.Models
{
    public class Bet
    {
        public int BetID { get; set; }
        public int UserID { get; set; }
        public int Wager { get; set; }
        public string Bettor { get; set; }
        public string Description { get; set; }
        public DateTime WagerDate { get; set; }
    }
}
