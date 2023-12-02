using BevBuddyWebApi.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BevBuddyWebApi.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection Connect()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
