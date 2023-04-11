using Microsoft.Data.SqlClient;

namespace DataAccess.DataConnection
{
    public interface ISqlConnectionFactory
    {
        SqlConnection GetConnection();
    }
}