using System.Data;

namespace BevBuddyWebApi.Interfaces
{
    public interface IBaseRepository
    {
        public IDbConnection Connect();
    }
}
