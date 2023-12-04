namespace BevBuddyWebApi.Models
{
    public class BetDto
    {
        public int BetID { get; set; }
        public int UserID { get; set; }
        public int Wager { get; set; }
        public string Bettor { get; set; }
        public string Description { get; set; }
        public DateTime WagerDate { get; set; }
    }
}
