using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Test.Repository
{
    public class Repository
    {
        private readonly IConfiguration _config;
        public Repository(IConfiguration config)
        {
            _config = config;
        }

        internal async Task<SqlConnection> OpenDBConnection()
        {
            SqlConnection sqlCon = new SqlConnection(ConfigSettings.ConfigConnectionString(_config));
            await sqlCon.OpenAsync();
            return sqlCon;
        }
    }
}