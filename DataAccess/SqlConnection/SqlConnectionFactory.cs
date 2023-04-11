using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DataConnection
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly IConfiguration _config;
        public SqlConnectionFactory(IConfiguration configuration)
        {
            _config = configuration;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString("default"));
        }
    }
}