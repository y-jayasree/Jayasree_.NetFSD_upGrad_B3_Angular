using System.Data;
using Microsoft.Data.SqlClient;

namespace WebApplication5.Models
{
    public class DapperContext
    {
        private readonly string _connectionString;
        public DapperContext(string connectionString) => _connectionString = connectionString;

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
